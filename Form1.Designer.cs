namespace 串口Test001
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_tx_send = new System.Windows.Forms.Button();
            this.btn_tx_clr = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rtbx_tx = new System.Windows.Forms.RichTextBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rtbx_rx = new System.Windows.Forms.RichTextBox();
            this.btn_rx_clr = new System.Windows.Forms.Button();
            this.cbox_handshake = new System.Windows.Forms.ComboBox();
            this.btn_cfg = new System.Windows.Forms.Button();
            this.cbox_parity_bit = new System.Windows.Forms.ComboBox();
            this.cbox_stop_bit = new System.Windows.Forms.ComboBox();
            this.cbox_data_bit = new System.Windows.Forms.ComboBox();
            this.cbox_baud = new System.Windows.Forms.ComboBox();
            this.cbox_ser_port = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtn_rx_hex = new System.Windows.Forms.RadioButton();
            this.rbtn_rx_asc = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1_timing_prd = new System.Windows.Forms.TextBox();
            this.checkBox_prd = new System.Windows.Forms.CheckBox();
            this.linkLabel_cmd = new System.Windows.Forms.LinkLabel();
            this.rbtn_tx_hex = new System.Windows.Forms.RadioButton();
            this.rbtn_tx_asc = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label_tx_cnt = new System.Windows.Forms.Label();
            this.label_rx_cnt = new System.Windows.Forms.Label();
            this.label_frame_cnt = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label_tip = new System.Windows.Forms.Label();
            this.toolTip_rbtn_rx_asc = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_rbtn_rx_hex = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_rbtn_tx_asc = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_rbtn_tx_hex_info = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_rbtn_tx_hex = new System.Windows.Forms.ToolTip(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_tx_send
            // 
            this.btn_tx_send.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_tx_send.ForeColor = System.Drawing.Color.Green;
            this.btn_tx_send.Location = new System.Drawing.Point(670, 6);
            this.btn_tx_send.Name = "btn_tx_send";
            this.btn_tx_send.Size = new System.Drawing.Size(90, 27);
            this.btn_tx_send.TabIndex = 0;
            this.btn_tx_send.Text = "发送";
            this.btn_tx_send.UseVisualStyleBackColor = true;
            this.btn_tx_send.Click += new System.EventHandler(this.btn_tx_send_Click);
            // 
            // btn_tx_clr
            // 
            this.btn_tx_clr.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_tx_clr.Location = new System.Drawing.Point(670, 107);
            this.btn_tx_clr.Name = "btn_tx_clr";
            this.btn_tx_clr.Size = new System.Drawing.Size(90, 27);
            this.btn_tx_clr.TabIndex = 0;
            this.btn_tx_clr.Text = "清除";
            this.btn_tx_clr.UseVisualStyleBackColor = true;
            this.btn_tx_clr.Click += new System.EventHandler(this.btn_tx_clr_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(226, 351);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(778, 166);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rtbx_tx);
            this.tabPage1.Controls.Add(this.btn_tx_send);
            this.tabPage1.Controls.Add(this.btn_tx_clr);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(770, 140);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "发送";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // rtbx_tx
            // 
            this.rtbx_tx.Location = new System.Drawing.Point(6, 6);
            this.rtbx_tx.Name = "rtbx_tx";
            this.rtbx_tx.Size = new System.Drawing.Size(658, 128);
            this.rtbx_tx.TabIndex = 3;
            this.rtbx_tx.Text = "";
            this.rtbx_tx.TextChanged += new System.EventHandler(this.rtbx_tx_TextChanged);
            this.rtbx_tx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtbx_tx_KeyPress);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Location = new System.Drawing.Point(226, 12);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(774, 333);
            this.tabControl2.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rtbx_rx);
            this.tabPage2.Controls.Add(this.btn_rx_clr);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(766, 307);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "接收";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // rtbx_rx
            // 
            this.rtbx_rx.Location = new System.Drawing.Point(6, 6);
            this.rtbx_rx.Name = "rtbx_rx";
            this.rtbx_rx.Size = new System.Drawing.Size(658, 295);
            this.rtbx_rx.TabIndex = 3;
            this.rtbx_rx.Text = "";
            this.rtbx_rx.TextChanged += new System.EventHandler(this.rtbx_rx_TextChanged);
            // 
            // btn_rx_clr
            // 
            this.btn_rx_clr.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_rx_clr.Location = new System.Drawing.Point(670, 274);
            this.btn_rx_clr.Name = "btn_rx_clr";
            this.btn_rx_clr.Size = new System.Drawing.Size(90, 27);
            this.btn_rx_clr.TabIndex = 0;
            this.btn_rx_clr.Text = "清除";
            this.btn_rx_clr.UseVisualStyleBackColor = true;
            this.btn_rx_clr.Click += new System.EventHandler(this.btn_rx_clr_Click);
            // 
            // cbox_handshake
            // 
            this.cbox_handshake.FormattingEnabled = true;
            this.cbox_handshake.Location = new System.Drawing.Point(63, 144);
            this.cbox_handshake.Name = "cbox_handshake";
            this.cbox_handshake.Size = new System.Drawing.Size(140, 20);
            this.cbox_handshake.TabIndex = 3;
            // 
            // btn_cfg
            // 
            this.btn_cfg.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_cfg.Location = new System.Drawing.Point(113, 170);
            this.btn_cfg.Name = "btn_cfg";
            this.btn_cfg.Size = new System.Drawing.Size(90, 27);
            this.btn_cfg.TabIndex = 0;
            this.btn_cfg.Text = "打开";
            this.btn_cfg.UseVisualStyleBackColor = true;
            this.btn_cfg.Click += new System.EventHandler(this.btn_cfg_Click);
            // 
            // cbox_parity_bit
            // 
            this.cbox_parity_bit.FormattingEnabled = true;
            this.cbox_parity_bit.Location = new System.Drawing.Point(63, 118);
            this.cbox_parity_bit.Name = "cbox_parity_bit";
            this.cbox_parity_bit.Size = new System.Drawing.Size(140, 20);
            this.cbox_parity_bit.TabIndex = 3;
            // 
            // cbox_stop_bit
            // 
            this.cbox_stop_bit.FormattingEnabled = true;
            this.cbox_stop_bit.Location = new System.Drawing.Point(63, 92);
            this.cbox_stop_bit.Name = "cbox_stop_bit";
            this.cbox_stop_bit.Size = new System.Drawing.Size(140, 20);
            this.cbox_stop_bit.TabIndex = 3;
            // 
            // cbox_data_bit
            // 
            this.cbox_data_bit.FormattingEnabled = true;
            this.cbox_data_bit.Location = new System.Drawing.Point(63, 66);
            this.cbox_data_bit.Name = "cbox_data_bit";
            this.cbox_data_bit.Size = new System.Drawing.Size(140, 20);
            this.cbox_data_bit.TabIndex = 3;
            // 
            // cbox_baud
            // 
            this.cbox_baud.FormattingEnabled = true;
            this.cbox_baud.Location = new System.Drawing.Point(63, 40);
            this.cbox_baud.Name = "cbox_baud";
            this.cbox_baud.Size = new System.Drawing.Size(140, 20);
            this.cbox_baud.TabIndex = 3;
            // 
            // cbox_ser_port
            // 
            this.cbox_ser_port.DropDownWidth = 200;
            this.cbox_ser_port.FormattingEnabled = true;
            this.cbox_ser_port.Location = new System.Drawing.Point(63, 14);
            this.cbox_ser_port.Name = "cbox_ser_port";
            this.cbox_ser_port.Size = new System.Drawing.Size(140, 20);
            this.cbox_ser_port.TabIndex = 3;
            this.cbox_ser_port.SelectedIndexChanged += new System.EventHandler(this.cbox_ser_port_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "流控制";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "校验位";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "停止位";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "数据位";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "波特率";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口号";
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.WriteBufferSize = 4096;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtn_rx_hex);
            this.groupBox1.Controls.Add(this.rbtn_rx_asc);
            this.groupBox1.Location = new System.Drawing.Point(8, 235);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "接收设置";
            // 
            // rbtn_rx_hex
            // 
            this.rbtn_rx_hex.AutoSize = true;
            this.rbtn_rx_hex.Location = new System.Drawing.Point(104, 21);
            this.rbtn_rx_hex.Name = "rbtn_rx_hex";
            this.rbtn_rx_hex.Size = new System.Drawing.Size(41, 16);
            this.rbtn_rx_hex.TabIndex = 0;
            this.rbtn_rx_hex.TabStop = true;
            this.rbtn_rx_hex.Text = "HEX";
            this.rbtn_rx_hex.UseVisualStyleBackColor = true;
            this.rbtn_rx_hex.MouseEnter += new System.EventHandler(this.rbtn_rx_hex_MouseEnter);
            this.rbtn_rx_hex.MouseLeave += new System.EventHandler(this.rbtn_rx_hex_MouseLeave);
            this.rbtn_rx_hex.MouseHover += new System.EventHandler(this.rbtn_rx_hex_MouseHover);
            // 
            // rbtn_rx_asc
            // 
            this.rbtn_rx_asc.AutoSize = true;
            this.rbtn_rx_asc.Location = new System.Drawing.Point(9, 21);
            this.rbtn_rx_asc.Name = "rbtn_rx_asc";
            this.rbtn_rx_asc.Size = new System.Drawing.Size(53, 16);
            this.rbtn_rx_asc.TabIndex = 0;
            this.rbtn_rx_asc.TabStop = true;
            this.rbtn_rx_asc.Text = "ASCII";
            this.rbtn_rx_asc.UseVisualStyleBackColor = true;
            this.rbtn_rx_asc.MouseEnter += new System.EventHandler(this.rbtn_rx_asc_MouseEnter);
            this.rbtn_rx_asc.MouseLeave += new System.EventHandler(this.rbtn_rx_asc_MouseLeave);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBox1_timing_prd);
            this.groupBox2.Controls.Add(this.checkBox_prd);
            this.groupBox2.Controls.Add(this.linkLabel_cmd);
            this.groupBox2.Controls.Add(this.rbtn_tx_hex);
            this.groupBox2.Controls.Add(this.rbtn_tx_asc);
            this.groupBox2.Location = new System.Drawing.Point(8, 412);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 124);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "发送设置";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(121, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "ms";
            // 
            // textBox1_timing_prd
            // 
            this.textBox1_timing_prd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1_timing_prd.Location = new System.Drawing.Point(76, 58);
            this.textBox1_timing_prd.Name = "textBox1_timing_prd";
            this.textBox1_timing_prd.Size = new System.Drawing.Size(38, 21);
            this.textBox1_timing_prd.TabIndex = 3;
            this.textBox1_timing_prd.Text = "200";
            this.textBox1_timing_prd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1_timing_prd.TextChanged += new System.EventHandler(this.textBox1_timing_prd_TextChanged);
            // 
            // checkBox_prd
            // 
            this.checkBox_prd.AutoSize = true;
            this.checkBox_prd.Location = new System.Drawing.Point(7, 63);
            this.checkBox_prd.Name = "checkBox_prd";
            this.checkBox_prd.Size = new System.Drawing.Size(72, 16);
            this.checkBox_prd.TabIndex = 2;
            this.checkBox_prd.Text = "循环周期";
            this.checkBox_prd.UseVisualStyleBackColor = true;
            this.checkBox_prd.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // linkLabel_cmd
            // 
            this.linkLabel_cmd.AutoSize = true;
            this.linkLabel_cmd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel_cmd.Location = new System.Drawing.Point(5, 104);
            this.linkLabel_cmd.Name = "linkLabel_cmd";
            this.linkLabel_cmd.Size = new System.Drawing.Size(63, 14);
            this.linkLabel_cmd.TabIndex = 1;
            this.linkLabel_cmd.TabStop = true;
            this.linkLabel_cmd.Text = "快捷指令";
            // 
            // rbtn_tx_hex
            // 
            this.rbtn_tx_hex.AutoSize = true;
            this.rbtn_tx_hex.Location = new System.Drawing.Point(100, 20);
            this.rbtn_tx_hex.Name = "rbtn_tx_hex";
            this.rbtn_tx_hex.Size = new System.Drawing.Size(41, 16);
            this.rbtn_tx_hex.TabIndex = 0;
            this.rbtn_tx_hex.TabStop = true;
            this.rbtn_tx_hex.Text = "HEX";
            this.rbtn_tx_hex.UseVisualStyleBackColor = true;
            this.rbtn_tx_hex.CheckedChanged += new System.EventHandler(this.rbtn_tx_hex_CheckedChanged);
            // 
            // rbtn_tx_asc
            // 
            this.rbtn_tx_asc.AutoSize = true;
            this.rbtn_tx_asc.Location = new System.Drawing.Point(5, 20);
            this.rbtn_tx_asc.Name = "rbtn_tx_asc";
            this.rbtn_tx_asc.Size = new System.Drawing.Size(53, 16);
            this.rbtn_tx_asc.TabIndex = 0;
            this.rbtn_tx_asc.TabStop = true;
            this.rbtn_tx_asc.Text = "ASCII";
            this.rbtn_tx_asc.UseVisualStyleBackColor = true;
            this.rbtn_tx_asc.CheckedChanged += new System.EventHandler(this.rbtn_tx_asc_CheckedChanged);
            this.rbtn_tx_asc.MouseEnter += new System.EventHandler(this.rbtn_tx_asc_MouseEnter);
            this.rbtn_tx_asc.MouseLeave += new System.EventHandler(this.rbtn_tx_asc_MouseLeave);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbox_handshake);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btn_cfg);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cbox_parity_bit);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cbox_stop_bit);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cbox_data_bit);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cbox_baud);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.cbox_ser_port);
            this.groupBox3.Location = new System.Drawing.Point(8, 11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(212, 218);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "串口配置";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(900, 519);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "复位计数";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_tx_cnt
            // 
            this.label_tx_cnt.AutoSize = true;
            this.label_tx_cnt.Location = new System.Drawing.Point(786, 524);
            this.label_tx_cnt.Name = "label_tx_cnt";
            this.label_tx_cnt.Size = new System.Drawing.Size(29, 12);
            this.label_tx_cnt.TabIndex = 6;
            this.label_tx_cnt.Text = "TX:0";
            // 
            // label_rx_cnt
            // 
            this.label_rx_cnt.AutoSize = true;
            this.label_rx_cnt.Location = new System.Drawing.Point(640, 524);
            this.label_rx_cnt.Name = "label_rx_cnt";
            this.label_rx_cnt.Size = new System.Drawing.Size(29, 12);
            this.label_rx_cnt.TabIndex = 6;
            this.label_rx_cnt.Text = "RX:0";
            // 
            // label_frame_cnt
            // 
            this.label_frame_cnt.AutoSize = true;
            this.label_frame_cnt.Location = new System.Drawing.Point(462, 524);
            this.label_frame_cnt.Name = "label_frame_cnt";
            this.label_frame_cnt.Size = new System.Drawing.Size(23, 12);
            this.label_frame_cnt.TabIndex = 6;
            this.label_frame_cnt.Text = "0/0";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label_tip
            // 
            this.label_tip.AutoSize = true;
            this.label_tip.Location = new System.Drawing.Point(8, 547);
            this.label_tip.Name = "label_tip";
            this.label_tip.Size = new System.Drawing.Size(41, 12);
            this.label_tip.TabIndex = 7;
            this.label_tip.Text = "说明：";
            // 
            // toolTip_rbtn_rx_asc
            // 
            this.toolTip_rbtn_rx_asc.AutomaticDelay = 100;
            this.toolTip_rbtn_rx_asc.AutoPopDelay = 1000;
            this.toolTip_rbtn_rx_asc.BackColor = System.Drawing.Color.Transparent;
            this.toolTip_rbtn_rx_asc.ForeColor = System.Drawing.SystemColors.Info;
            this.toolTip_rbtn_rx_asc.InitialDelay = 100;
            this.toolTip_rbtn_rx_asc.ReshowDelay = 500;
            this.toolTip_rbtn_rx_asc.UseAnimation = false;
            this.toolTip_rbtn_rx_asc.UseFading = false;
            // 
            // toolTip_rbtn_rx_hex
            // 
            this.toolTip_rbtn_rx_hex.UseAnimation = false;
            this.toolTip_rbtn_rx_hex.UseFading = false;
            // 
            // toolTip_rbtn_tx_hex_info
            // 
            this.toolTip_rbtn_tx_hex_info.AutoPopDelay = 1000;
            this.toolTip_rbtn_tx_hex_info.InitialDelay = 500;
            this.toolTip_rbtn_tx_hex_info.IsBalloon = true;
            this.toolTip_rbtn_tx_hex_info.ReshowDelay = 100;
            this.toolTip_rbtn_tx_hex_info.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // toolTip_rbtn_tx_hex
            // 
            this.toolTip_rbtn_tx_hex.AutoPopDelay = 1000;
            this.toolTip_rbtn_tx_hex.InitialDelay = 500;
            this.toolTip_rbtn_tx_hex.IsBalloon = true;
            this.toolTip_rbtn_tx_hex.ReshowDelay = 100;
            this.toolTip_rbtn_tx_hex.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(770, 140);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Servo-s";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 568);
            this.Controls.Add(this.label_tip);
            this.Controls.Add(this.label_rx_cnt);
            this.Controls.Add(this.label_tx_cnt);
            this.Controls.Add(this.label_frame_cnt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tabControl2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "串口测试001";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_tx_send;
        private System.Windows.Forms.Button btn_tx_clr;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_rx_clr;
        private System.Windows.Forms.RichTextBox rtbx_tx;
        private System.Windows.Forms.RichTextBox rtbx_rx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbox_handshake;
        private System.Windows.Forms.Button btn_cfg;
        private System.Windows.Forms.ComboBox cbox_parity_bit;
        private System.Windows.Forms.ComboBox cbox_stop_bit;
        private System.Windows.Forms.ComboBox cbox_data_bit;
        private System.Windows.Forms.ComboBox cbox_baud;
        private System.Windows.Forms.ComboBox cbox_ser_port;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtn_rx_hex;
        private System.Windows.Forms.RadioButton rbtn_rx_asc;
        private System.Windows.Forms.RadioButton rbtn_tx_hex;
        private System.Windows.Forms.RadioButton rbtn_tx_asc;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_tx_cnt;
        private System.Windows.Forms.Label label_rx_cnt;
        private System.Windows.Forms.Label label_frame_cnt;
        private System.Windows.Forms.LinkLabel linkLabel_cmd;
        private System.Windows.Forms.TextBox textBox1_timing_prd;
        private System.Windows.Forms.CheckBox checkBox_prd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label_tip;
        private System.Windows.Forms.ToolTip toolTip_rbtn_rx_asc;
        private System.Windows.Forms.ToolTip toolTip_rbtn_rx_hex;
        private System.Windows.Forms.ToolTip toolTip_rbtn_tx_asc;
        private System.Windows.Forms.ToolTip toolTip_rbtn_tx_hex_info;
        private System.Windows.Forms.ToolTip toolTip_rbtn_tx_hex;
        private System.Windows.Forms.TabPage tabPage3;
    }
}

