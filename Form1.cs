using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.IO.Ports;
using System.Management;
using System.Diagnostics;




namespace 串口Test001
{
    public partial class Form1 : Form
    {
        enum charMode : byte
        { 
            ASCII,
            HEX,
        };

  

        public bool port_status = false;

        public string[] portNameFull = null;    // "COMx # USR-SERIAL PORT"
        public string[] portName = null;  // "COMx"
        public string[] port_baud = new string[] { "600", "1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200", "256000", "460800", "921600", "1000000", "2000000" };
        public string[] port_data_bit = new string[] { "5", "6", "7", "8" };
        public string[] port_stop_bit = new string[] { "1", "1.5", "2" };
        public string[] port_parity_bit = new string[] { "NONE", "ODD", "EVEN", "MARK", "SPACE" };
        public string[] port_handshake = new string[] { "NONE", "XON/XOFF", "RTS/CTS", "DTR/DSR", "RTS/CTS/XON/XOFF", "DTR/DSR/XON/XOFF" };
        public string[] port_btn_state = new string[] { "打开", "关闭" };

        public long curr_time_utc;
        //DateTime curr_time;

        public string date_time;

        public int tx_cnt = 0, rx_cnt = 0, tx_frame_cnt = 0, rx_frame_cnt = 0;

        private bool prd_send_enable = false; // 周期性发送是否使能
        private bool prd_sending_state = false;    //周期性发送是否进行中
        private charMode tx_char_mode = charMode.ASCII;
        private charMode rx_char_mode = charMode.ASCII;

        private string tx_data; // buf for tx, 串口发送数据缓存，以ASCII类型显示
        
        /*
         * 复位收 发 帧计数
         */
        private void lable_frame_cnt_show(int rxFrameCnt, int txFrameCnt)
        {
            label_frame_cnt.Text = rxFrameCnt.ToString() + "/" + txFrameCnt.ToString();
        }
        /*
         * 复位发送计数
         */
        private void lable_tx_cnt_show(int value)
        {
            label_tx_cnt.Text = "TX:" + value.ToString();
        }
        /*
            复位接收计数
         */
        private void lable_rx_cnt_show(int value)
        {
            label_rx_cnt.Text = "RX:" + value.ToString();
        }

        /*
            复位收、发计数，以及帧计数的 Lable
         */
        private void cnt_reset()
        {
            tx_cnt = 0;
            rx_cnt = 0;
            tx_frame_cnt = 0;
            rx_frame_cnt = 0;
            lable_tx_cnt_show(tx_cnt);
            lable_rx_cnt_show(rx_cnt);
            lable_frame_cnt_show(rx_frame_cnt, tx_frame_cnt);
        }
               

        private void getPortDevName(ref string[] portDevName)
        {
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher
                ("select * from Win32_PnPEntity where Name like '%(COM%'"))
            {
                List<string> stringList = new List<string>();

                var hardInfos = searcher.Get();
                foreach (var hardInfo in hardInfos)
                {
                    if (hardInfo.Properties["Name"].Value != null)
                    {
                        string deviceName = hardInfo.Properties["Name"].Value.ToString(); //deviceName like--- "USB-Enhanced-SERIAL CH343 (COM8)"
                        Console.WriteLine(deviceName);
                        stringList.Add(deviceName);
                    }
                }
                portDevName = stringList.ToArray();
            }
        }

        /*
            usb xxx xxx (COMx) ---> COMx #usb xxx xxx
        */
        static string ConvertString(string input)
        {
            // 找到左括号的位置
            int startIndex = input.IndexOf('(');
            // 找到右括号的位置
            int endIndex = input.IndexOf(')');

            // 提取括号内的内容（COM端口号）
            string comPort = input.Substring(startIndex + 1, endIndex - startIndex - 1);
            // 提取括号外的内容
            string otherPart = input.Substring(0, startIndex) + input.Substring(endIndex + 1);

            // 重新组合字符串
            string result = $"{comPort} #{otherPart}";
            return result;
        }

        /*
            only get "COMx" form like "COMx # user-xxxx port"
         */
        static string StringGetComx(string input)
        {
            int startIndex = input.IndexOf('C');
            int endIndex = input.IndexOf('#');

            string comPort = input.Substring(startIndex, endIndex - startIndex - 1);

            return comPort;
        }


        public void changeStringOrder(ref string[] strIn)
        {
            List<string> stringList = new List<string>();

            foreach (string str in strIn)
            {
                string str_new = ConvertString(str);
                stringList.Add(str_new);
            }
            strIn = stringList.ToArray();
        }


        /*
            该函数可以干杯 combobox.Iterms.Addrange(数据名) 替代
         */
        public void cbox_add_fxn(System.Windows.Forms.ComboBox cbox, string[] items)
        {
            int size = items.Length;

            for (int i = 0; i < size; i++)
            {
                cbox.Items.Add(items[i]);
            }
        }

        /*
            设置定时器定时间隔
         */
        private void TimerCfg()
        {
            string str = textBox1_timing_prd.Text;  //获取定时间隔字符串
            Int32 interval = Convert.ToInt32(str);  //转为数值
            if(interval != 0)                       //数值判断
                timer1.Interval = interval;
            else timer1.Interval = 100;             //为0时，改用默认100ms
        }

        private void TimerInit()
        {
            TimerCfg();// 读取当前默认值，并更新定时器间隔
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rtbx_rx.Text = "";
            rtbx_tx.Text = "Hello !";

            tx_data = rtbx_tx.Text; //when init

            //配置区下拉框项填充
            cbox_baud.Items.AddRange(port_baud);
            cbox_data_bit.Items.AddRange(port_data_bit);
            cbox_stop_bit.Items.AddRange(port_stop_bit);
            cbox_parity_bit.Items.AddRange(port_parity_bit);
            cbox_handshake.Items.AddRange(port_handshake);

            //配置区下拉初始值
            cbox_baud.SelectedIndex = 8;    // 8---115200
            cbox_data_bit.SelectedIndex = 3;
            cbox_stop_bit.SelectedIndex = 0;
            cbox_parity_bit.SelectedIndex = 0;
            cbox_handshake.SelectedIndex = 0;

            getPortDevName(ref portNameFull);

            changeStringOrder(ref portNameFull);

            cbox_ser_port.Items.AddRange(portNameFull);// 获取可用串口号, // 可以省略 System.IO.Ports.
            if(cbox_ser_port.Items.Count > 0)// 若有串口识别，默认选中第一个识别的，方便操作；没有就不选中
                cbox_ser_port.SelectedIndex = 0;

            btn_cfg.Text = "打开";

            // ASCII HEX选择默认为ASCII
            rbtn_rx_asc.Checked = true;
            rbtn_tx_asc.Checked = true;

    
            TimerInit();
            Init_ToolTip();

            //富文本框显示优化
            //rtbx_rx.UseAntiAlias = true;
            //rtbx_rx.TextAlign = HorizontalAlignment.Top;

            rtbx_tx.KeyPress += new KeyPressEventHandler(rtbx_tx_KeyPress);// 在构造函数中订阅事件
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }



        private void btn_tx_clr_Click(object sender, EventArgs e)
        {
            rtbx_tx.Text = "";

            /*// 创建 ToolTip 控件
            ToolTip toolTip = new ToolTip();
            // 设置 ToolTip 的文本
            toolTip.SetToolTip(btn_tx_clr, "这是一个提示信息");*/

           /* // 创建 ToolTip 控件
            ToolTip toolTip = new ToolTip();

            // 将 ToolTip 关联到指定的控件
            toolTip.SetToolTip(btn_tx_clr, "这是按钮的小提示");

            // 可以设置 ToolTip 的显示时间、样式等
            toolTip.AutoPopDelay = 5000; // ToolTip 显示5秒后消失
            toolTip.InitialDelay = 1000; // 鼠标悬停1秒后显示 ToolTip
            toolTip.ReshowDelay = 500; // ToolTip 消失后，鼠标再次悬停0.5秒后显示
            toolTip.ToolTipTitle = "注意！"; // 设置 ToolTip 标题
            toolTip.ToolTipIcon = ToolTipIcon.Info; // 设置 ToolTip 小图标*/




        }

        private void PortCfgAreaLock()
        {
            cbox_baud.Enabled = true;
            cbox_data_bit.Enabled = true;
            cbox_stop_bit.Enabled = true;
            cbox_parity_bit.Enabled = true;
            cbox_handshake.Enabled = true;
            cbox_ser_port.Enabled = true;
        }
        private void PortCfgAreaUnlock()
        {
            cbox_baud.Enabled = false;
            cbox_data_bit.Enabled = false;
            cbox_stop_bit.Enabled = false;
            cbox_parity_bit.Enabled = false;
            cbox_handshake.Enabled = false;
            cbox_ser_port.Enabled = false;
        }

        private void SerialCfg()
        {
            serialPort1.PortName = StringGetComx(cbox_ser_port.Text);
            serialPort1.BaudRate = Convert.ToInt32(cbox_baud.Text);
            serialPort1.DataBits = Convert.ToInt16(cbox_data_bit.Text);

            if (cbox_parity_bit.Text.Equals("NONE"))
                serialPort1.Parity = Parity.None;
            else if (cbox_parity_bit.Text.Equals("ODD"))
                serialPort1.Parity = Parity.Odd;
            else if (cbox_parity_bit.Text.Equals("EVEN"))
                serialPort1.Parity = Parity.Even;
            else if (cbox_parity_bit.Text.Equals("MARK"))
                serialPort1.Parity = Parity.Mark;
            else if (cbox_parity_bit.Text.Equals("SPACE"))
                serialPort1.Parity = Parity.Space;

            if (cbox_stop_bit.Text.Equals("1"))
                serialPort1.StopBits = StopBits.One;
            else if (cbox_stop_bit.Text.Equals("1.5"))
                serialPort1.StopBits = StopBits.OnePointFive;
            else if (cbox_stop_bit.Text.Equals("2"))
                serialPort1.StopBits = StopBits.Two;

            //System.IO.Ports.Handshake.XOnXOff
            if (cbox_handshake.Text.Equals("NONE"))
                serialPort1.Handshake = Handshake.None;
            else if (cbox_handshake.Text.Equals("XON/XOFF"))
                serialPort1.Handshake = Handshake.XOnXOff;
            else if (cbox_handshake.Text.Equals("RTS/CTS"))
                serialPort1.Handshake = Handshake.RequestToSend;
            else if (cbox_handshake.Text.Equals("RTS/CTS/XON/XOFF"))
                serialPort1.Handshake = Handshake.RequestToSendXOnXOff;
        }

        /*
            启动发送(一般指定时发送)
            需要禁止发送区的配置部分
         */
        private void SendingStart()
        {
            checkBox_prd.Enabled = false;
            textBox1_timing_prd.Enabled = false;
        }

        /*
            停止发送状态（一般指定时发送）
            需要恢复发送区的设置为使能
         */
        private void SendingStop()
        {            
            checkBox_prd.Enabled = true;
            textBox1_timing_prd.Enabled = true;
        }

        /*
            -----------------串口开关键------------------------
         */
        private void btn_cfg_Click(object sender, EventArgs e)
        {
            try {
                //-------------串口按键关闭处理---------------------
                if (serialPort1.IsOpen) //若已经打开，则关闭
                {
                    if (prd_sending_state == true)//定时发送中...
                    {
                        prd_sending_state = false;  //发送状态停止
                        SendingStop();
                        timer1.Stop();                        
                    }

                    serialPort1.Close();

                    //按键显示恢复 “发送”---即普通状态
                    btn_tx_send.Text = "发送";

                    //关闭后，下拉选项使能
                    PortCfgAreaLock();

                    btn_cfg.Text = "打开";
                    port_status = false;                   

                }//---------------串口按键开启处理----------------
                else
                {
                    //开启后，配置区
                    PortCfgAreaUnlock();

                    //串口设置
                    SerialCfg();
                    serialPort1.Open();

                    port_status = true;
                    btn_cfg.Text = "关闭";
                    //btn_cfg.BackColor = Color.Firebrick;
                    btn_tx_send.Enabled = true;

                    //if(pr)
                }
            }
            catch (Exception ex)
            {
                //异常处理

                //捕获到异常，创建一个新的对象，之前的不可以再用
                serialPort1 = new System.IO.Ports.SerialPort();

                //刷新COM口选项
                cbox_ser_port.Items.Clear();
                cbox_ser_port.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());

                //响铃并显示异常给用户
                System.Media.SystemSounds.Beep.Play();

                MessageBox.Show(ex.Message);

                cbox_baud.Enabled = true;
                cbox_data_bit.Enabled = true;
                cbox_stop_bit.Enabled = true;
                cbox_parity_bit.Enabled = true;
                cbox_handshake.Enabled = true;
                cbox_ser_port.Enabled = true;

                btn_cfg.Text = "打开";
                //btn_cfg.BackColor = Color.ForestGreen;
                port_status = false;
                btn_tx_send.Enabled = false;
            }



        }

        private string asc_to_hex(string asc_str)
        {
            byte[] bytes = Encoding.Default.GetBytes(asc_str);  
            string hexString = BitConverter.ToString(bytes);// 转成16进制字符串默认中间带“-”，需要用“ ”替换
            hexString = hexString.Replace("-", " ");
            return hexString;
        }

        /*
         * ASCII string 转为 16进制字节 加空格
         */
        private string asc_to_hex2(string asc_str)
        {
            byte[] bad = System.Text.ASCIIEncoding.Default.GetBytes(asc_str);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bad)
            {
                sb.Append(b.ToString("X02") + " ");
            }
            return sb.ToString();
        }

        /*
            16 进制的字符串，转为数组
            "31 32 33 34" ---> [1,2,3,4]
         */
       /* private static byte[] HexStringToByteArray(string hexString)
        {
            if( (hexString == null) || (hexString.Length <2))
            {
                return null;
            }

            int length = hexString.Length;  //获取字符串长度
            byte[] bytes = new byte[length / 2];    //新数组长度减半
            for (int i = 0; i < length; i += 2)
            {
                string hexValue = hexString.Substring(i, 2);
                //bytes[i / 2] = Convert.ToByte(hexValue, 16);
                //bytes[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            }
            return bytes;
        }*/

        /*private string hex_to_asc(string hexString)
        {
            byte[] bytes = HexStringToByteArray(hexString);

            return Encoding.UTF8.GetString(bytes);
        }*/

        private void rbtn_tx_hex_CheckedChanged(object sender, EventArgs e)
        {
            tx_char_mode = charMode.HEX;

            string buf = tx_data;
            buf = asc_to_hex2(buf);
            rtbx_tx.Text = buf;
        }

        private void rbtn_tx_asc_CheckedChanged(object sender, EventArgs e)
        {
            tx_char_mode = charMode.ASCII;
            rtbx_tx.Text = tx_data;
        }

        private void cbox_ser_port_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_prd.Checked == true)//选中,使能定时发送
            {
                prd_send_enable = true;
                textBox1_timing_prd.Enabled = false;    //时间调节禁止
            }
            else { //未选中， 取消循环周期设置
                prd_send_enable = false;
                textBox1_timing_prd.Enabled = true;     //时间调节允许
            }
        }

        // 接收清除按键
        private void btn_rx_clr_Click(object sender, EventArgs e)
        {
            rtbx_rx.Text = "";
        }

        private void textBox1_timing_prd_TextChanged(object sender, EventArgs e)
        {
            TimerCfg();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            send_msg();
        }

        private void rtbx_rx_TextChanged(object sender, EventArgs e)
        {
            rtbx_rx.SelectionStart = rtbx_rx.Text.Length;
            rtbx_rx.SelectionLength = 0;
            rtbx_rx.ScrollToCaret();
        }

        /*private void rtbx_tx_TextChanged(object sender, EventArgs e)
        {

        }*/

        private void Init_ToolTip()
        {
            // 设置 ToolTip 的显示时间
            //toolTip1.AutoPopDelay = 100; // 提示自动消失的时间（毫秒）
            //toolTip1.InitialDelay = 100; // 鼠标悬停后显示提示的延迟时间（毫秒）
            //toolTip1.ReshowDelay = 500;   // 提示消失后，鼠标再次悬停显示提示的延迟时间（毫秒）
                                         // 设置 ToolTip 的显示位置
            //toolTip.ToolTipTitle = "注意!!!"; // 可选：设置提示的标题
            //toolTip.ToolTipIcon = ToolTipIcon.Info; // 可选：设置提示的图标

            // 将 ToolTip 关联到控件
            //toolTip_rbtn_rx_asc.SetToolTip(rbtn_tx_hex, "16进制下，不可输入");
         
            //toolTip.SetToolTip(rbtn_rx_asc, "按ASCII显示接收的内容");
            // ...可以为其他控件设置 ToolTip
        }


        private void rtbx_tx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tx_char_mode == charMode.HEX)
            {
                // 允许数字、字母A-F、a-f、空格和回车
                if (char.IsDigit(e.KeyChar) ||
                    (e.KeyChar >= 'A' && e.KeyChar <= 'F') ||
                    (e.KeyChar >= 'a' && e.KeyChar <= 'f') ||
                    e.KeyChar == ' ' || // 空格
                    e.KeyChar == '\r')   // 回车键
                {
                    // 如果是合法字符，则允许输入
                }
                else
                {
                    // 如果不是合法字符，则阻止输入
                    e.Handled = true;
                    toolTip_rbtn_tx_hex_info.ToolTipTitle = "注意！";
                    toolTip_rbtn_tx_hex_info.Show("发送数据以16进制显示", rbtn_tx_hex, 40, 5);
                }
            }
        }

        private void rbtn_rx_asc_MouseEnter(object sender, EventArgs e)
        {
            //toolTip1.Active = true;
            toolTip_rbtn_rx_asc.Show("接收数据以ASCII显示", label_tip, 40,-4);
        }

        private void rbtn_rx_asc_MouseLeave(object sender, EventArgs e)
        {
            //toolTip1.Active = false;
            toolTip_rbtn_rx_asc.Hide(rbtn_rx_asc);
        }

        private void rbtn_rx_hex_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void rbtn_rx_hex_MouseLeave(object sender, EventArgs e)
        {
            // toolTip1.Active = false;
            toolTip_rbtn_rx_hex.Hide(rbtn_rx_hex);
        }

        private void rbtn_rx_hex_MouseHover(object sender, EventArgs e)
        {
            //toolTip1.Active = true;
            toolTip_rbtn_rx_hex.Show("接收数据以16进制显示", label_tip, 40, -4);
        }

        private void rbtn_tx_asc_MouseEnter(object sender, EventArgs e)
        {
            toolTip_rbtn_rx_asc.Show("发送数据以ASCII进制显示", label_tip, 40, -4);
        }

        private void rbtn_tx_asc_MouseLeave(object sender, EventArgs e)
        {
            toolTip_rbtn_rx_asc.Hide(rbtn_tx_asc);
        }

        private readonly object lockObject = new object();

        /*
            串口接收事假处理
         */
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            lock (lockObject)
            {
                if (serialPort1.BytesToRead > 0)
                {
                    byte[] bytes = new byte[serialPort1.BytesToRead];
                    serialPort1.Read(bytes, 0, bytes.Length);
                    HandleReceivedData(bytes);
                }
            }
        }

        private void HandleReceivedData(byte[] bytes)
        {
            // 在这里处理接收到的数据
            string receivedData = System.Text.Encoding.ASCII.GetString(bytes);
            Console.WriteLine("Received: " + receivedData);
        }

        private void rtbx_tx_TextChanged(object sender, EventArgs e)
        {

        }

        /*
            标准化格式转换 ( 加间隔，补齐, 小写字母转大写打印) ， 暂不考虑转换到ASCII  
        
            每次取2个  （有效字符： 数字 或 字母， 字母必须是HEX状态的 a~f 或 A~F）
                全有效字符      填数字 + 空格
                数字/+空格
         */
        private string FormatHexString(string hexString)
        {
            // 创建一个新的StringBuilder来构建最终的字符串
            StringBuilder formattedHexString = new StringBuilder();

            for (int i = 0; i < hexString.Length;)// 执行字符串总长度，i跳跃在后面设置
            {
                string temp = hexString.Substring(i, Math.Min(2, hexString.Length - i)); // 取2 个或 剩余

                byte space_type = 0;    // 0 --NONE, 1 --- "x " , 2----" x", 3---"  "

                string char_1 = "";
                string char_2 = "";

                char_1 = temp.Substring(0, 1);

                if (char_1 == " ")
                    space_type |= 0x02;

                if (temp.Length == 2)                    
                {
                    char_2 = temp.Substring(1, 1);
                    if (char_2 == " ")
                        space_type |= 0x01;
                }
                else space_type |= 0x01; //add " ", if length only get 1


                switch (space_type)
                {
                    case 0:  // full valid chars
                        formattedHexString.Append(temp);
                        formattedHexString.Append(" ");//加空格到最终字符串
                        i += 2;
                        break;
                    case 1:  //"x ", 后面一个是空格，需要去空格，前面补0
                        temp = temp.Replace(" ", "");//去掉空格，得单个字符（一半字节的）
                        formattedHexString.Append("0");
                        formattedHexString.Append(temp);
                        formattedHexString.Append(" ");//加空格到最终字符串
                        i += 2;
                        break;
                    case 2: //" x", 前面一个是空格，直接跳过
                        i++;
                        break;
                    case 3: //"  ", 两个都是空格，跳过，没有有效数据
                        i += 2;
                        break;  
                    default: break;
                }


            }

            return formattedHexString.ToString();

            /*// 去除可能存在的空格
            hexString = hexString.Replace(" ", "");

            // 创建一个新的StringBuilder来构建最终的字符串
            StringBuilder formattedHexString = new StringBuilder();

            // 每两个字符添加一个空格，如果字符不足两个则在前面补 '0'
            for (int i = 0; i < hexString.Length; i += 2)
            {
                // 如果当前位置不是成对的，则在前面补 '0'
                if (i + 1 == hexString.Length)
                {
                    formattedHexString.Append("0");
                }

                // 将两个十六进制字符添加到StringBuilder，如果只有一个字符则添加它和前面的 '0'
                formattedHexString.Append(hexString.Substring(i, Math.Min(2, hexString.Length - i)));

                // 添加一个空格，除非是最后一个字节
                if (i < hexString.Length - 2)
                {
                    formattedHexString.Append(" ");
                }
            }

            // 确保每个字节都是两个字符，不足两位的在其前面补 '0'
            string result = formattedHexString.ToString();
            if (result.Length % 4 != 0)
            {
                result = "0" + result;
            }

            return result;*/


            /*string[] parts = hexString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Use StringBuilder to efficiently build the formatted string
            StringBuilder formattedNumber = new StringBuilder();

            foreach (string part in parts)
            {
                // Process each part from right to left, two digits at a time
                for (int i = part.Length; i > 0; i -= 2)
                {
                    // Get the substring from the current position, but at most 2 characters
                    int startIndex = Math.Max(0, i - 2);
                    string twoDigits = part.Substring(startIndex, Math.Min(2, i - startIndex));

                    // Prepend the two digits to the StringBuilder (with a space if not the first group)
                    if (formattedNumber.Length > 0 && part != parts[parts.Length - 1])
                    {
                        formattedNumber.Insert(0, " ");
                    }
                    formattedNumber.Insert(0, twoDigits);
                }
            }

            return formattedNumber.ToString();*/
        
    }

        /*
            输入16进制字符串不得有空格
         */
        static string HexToAscii(string hexString)
        {
            if (hexString == null)
                throw new ArgumentNullException(nameof(hexString));

            if (hexString.Length % 2 != 0)
                throw new ArgumentException("Hex string must have an even number of characters.", nameof(hexString));

            StringBuilder asciiString = new StringBuilder();
            for (int i = 0; i < hexString.Length; i += 2)
            {
                string hexByte = hexString.Substring(i, 2);
                int decimalValue = Convert.ToInt32(hexByte, 16);
                asciiString.Append((char)decimalValue);
            }

            return asciiString.ToString();
        }



        private void send_msg()
        {
            if (serialPort1.IsOpen)
            {
                string msg_send = "";
                string format_hex_string = "";  //hex string with space

                //发送
                if (tx_char_mode == charMode.ASCII)
                {   
                    tx_data = rtbx_tx.Text; // 原始ASCII数据
                    msg_send = tx_data;
                }
                else {//tx_char_mode  HEX
                    format_hex_string = FormatHexString(rtbx_tx.Text);// 转为标准Hex字符串 "xx yy zz "
                    string hex_string_no_space = format_hex_string.Replace(" ", "");//转为去空格hex字符串 "xxyyzz"
                    string ascii_string = HexToAscii(hex_string_no_space);// 转为 ASCII字符串
                    msg_send = ascii_string;  
                }

                serialPort1.Write(msg_send);

                //打印
                //发送格式： 由这个决定 tx_char_mode = charMode.ASCII;
                

                string print_msg = "";
                string msg_format = "";
                string print_tx_data = "";

                date_time = System.DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss.fff]"); //获取时间戳
                print_msg += date_time;// 填充时间戳

                if (rbtn_tx_asc.Checked == true)
                {
                    msg_format = "ASCII/";
                    print_tx_data = msg_send;
                }
                else
                {
                    msg_format = "HEX/";
                    print_tx_data = format_hex_string;
                }
                print_msg += "# SEND " + msg_format + msg_send.Length.ToString() + " >>>\n";// 填充 格式 长度
                print_msg += print_tx_data + "\n";

                rtbx_rx.Text += print_msg;


                // 统计
                tx_cnt += msg_send.Length;
                tx_frame_cnt++;

                lable_tx_cnt_show(tx_cnt);
                lable_frame_cnt_show(rx_frame_cnt, tx_frame_cnt);


                //文件输出（暂不处理）




                /* rtbx_rx.Text += temp;
                 if (rbtn_tx_asc.Checked == true)
                 {
                     //ASCII
                     rtbx_rx.Text += tx_msg;
                 }
                 else//HEX
                 {
                     byte[] bytes = Encoding.Default.GetBytes(tx_msg);
                     string hexString = BitConverter.ToString(bytes);
                     hexString = hexString.Replace("-", " ");
                     rtbx_rx.Text += hexString;
                 }*/







            }
        }
        //
        //------------------------------发送键------------------------------
        //
        private void btn_tx_send_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (rtbx_tx.Text != "") //发送区不为空
                {
                    if (prd_send_enable == true)//周期性发送
                    {
                        if (prd_sending_state == false)//未启动发送
                        {
                            prd_sending_state = true;
                            //操作区禁用
                            SendingStart();
                          
                            //按键显示提示文字
                            btn_tx_send.Text = "停止发送";

                            //启动定时器相关
                            timer1.Start(); 
                            if(timer1.Interval > 20)// <= 20ms的，等定时触发
                                send_msg(); // 在间隔很短的情况下，按首次定时到发送；其他则首次在按键按下后，立即发送
                        }
                        else//已经启动发送, 则停止
                        {
                            prd_sending_state = false;
                            checkBox_prd.Enabled = true;
                            textBox1_timing_prd.Enabled = true;
                            //停止定时
                            timer1.Stop();
                            
                            //按键显示恢复 “发送”---即普通状态
                            btn_tx_send.Text = "发送";
                        }
                    }
                    else
                    {// 单次发送 
                        send_msg();


                    }

                    

                    
                }
                else { //已连接，发送区为空
                    MessageBox.Show("发送区不能为空！！！");
                }

            }
            else {//未连接或断开，发送区为空，
                MessageBox.Show("发送失败，串口未连接或已经拔出！！！");
            }
        }     

        

        private void button1_Click(object sender, EventArgs e)
        {
            cnt_reset();
        }
    }
}
