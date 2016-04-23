namespace WavAn
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.MainMenu = new System.Windows.Forms.MenuStrip();
			this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.SettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.TopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.TailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabControlMain = new System.Windows.Forms.TabControl();
			this.tabPageControl = new System.Windows.Forms.TabPage();
			this.label8 = new System.Windows.Forms.Label();
			this.textBoxFrame = new System.Windows.Forms.TextBox();
			this.textBoxOffset = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.tabPageHeader = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBoxQbit = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBoxBlockSize = new System.Windows.Forms.TextBox();
			this.textBoxFormatTag = new System.Windows.Forms.TextBox();
			this.textBoxByteRate = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxChannels = new System.Windows.Forms.TextBox();
			this.textBoxFs = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tabPageHeaderEx = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.cBTopBackCenter = new System.Windows.Forms.CheckBox();
			this.cBTopFrontCenter = new System.Windows.Forms.CheckBox();
			this.cBTopBackRight = new System.Windows.Forms.CheckBox();
			this.cBTopBackLeft = new System.Windows.Forms.CheckBox();
			this.cBTopCenter = new System.Windows.Forms.CheckBox();
			this.cBTopFrontRight = new System.Windows.Forms.CheckBox();
			this.cBTopFrontLeft = new System.Windows.Forms.CheckBox();
			this.cBFrontRightOfCenter = new System.Windows.Forms.CheckBox();
			this.cBFrontLeftOfCenter = new System.Windows.Forms.CheckBox();
			this.cBReserved = new System.Windows.Forms.CheckBox();
			this.cBSideRight = new System.Windows.Forms.CheckBox();
			this.cBSideLeft = new System.Windows.Forms.CheckBox();
			this.cBBackCenter = new System.Windows.Forms.CheckBox();
			this.cBBackRight = new System.Windows.Forms.CheckBox();
			this.cBBackLeft = new System.Windows.Forms.CheckBox();
			this.cBLowFreq = new System.Windows.Forms.CheckBox();
			this.cBFrontCenter = new System.Windows.Forms.CheckBox();
			this.cBFrontRight = new System.Windows.Forms.CheckBox();
			this.cBFrontLeft = new System.Windows.Forms.CheckBox();
			this.textBoxGUID = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.labelSamples = new System.Windows.Forms.Label();
			this.textBoxSamples = new System.Windows.Forms.TextBox();
			this.openFD = new System.Windows.Forms.OpenFileDialog();
			this.rTBMain = new System.Windows.Forms.RichTextBox();
			this.toolStripContainerMain = new System.Windows.Forms.ToolStripContainer();
			this.toolStripMain = new System.Windows.Forms.ToolStrip();
			this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripCBDisp = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripButtonPrev = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonPrevL = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonNextL = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonNext = new System.Windows.Forms.ToolStripButton();
			this.MainMenu.SuspendLayout();
			this.tabControlMain.SuspendLayout();
			this.tabPageControl.SuspendLayout();
			this.tabPageHeader.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPageHeaderEx.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.toolStripContainerMain.ContentPanel.SuspendLayout();
			this.toolStripContainerMain.TopToolStripPanel.SuspendLayout();
			this.toolStripContainerMain.SuspendLayout();
			this.toolStripMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainMenu
			// 
			this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.ViewToolStripMenuItem,
            this.HelpToolStripMenuItem});
			this.MainMenu.Location = new System.Drawing.Point(0, 0);
			this.MainMenu.Name = "MainMenu";
			this.MainMenu.Size = new System.Drawing.Size(633, 26);
			this.MainMenu.TabIndex = 0;
			this.MainMenu.Text = "menuStrip1";
			// 
			// FileToolStripMenuItem
			// 
			this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.CloseToolStripMenuItem,
            this.ExitToolStripMenuItem});
			this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
			this.FileToolStripMenuItem.Size = new System.Drawing.Size(85, 22);
			this.FileToolStripMenuItem.Text = "ファイル(&F)";
			// 
			// OpenToolStripMenuItem
			// 
			this.OpenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("OpenToolStripMenuItem.Image")));
			this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
			this.OpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.OpenToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.OpenToolStripMenuItem.Text = "開く(&O)";
			this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
			// 
			// CloseToolStripMenuItem
			// 
			this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
			this.CloseToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.CloseToolStripMenuItem.Text = "閉じる(&C)";
			this.CloseToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
			// 
			// ExitToolStripMenuItem
			// 
			this.ExitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ExitToolStripMenuItem.Image")));
			this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
			this.ExitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.ExitToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.ExitToolStripMenuItem.Text = "終了(&X)";
			this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
			// 
			// ViewToolStripMenuItem
			// 
			this.ViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolBarToolStripMenuItem,
            this.toolStripSeparator2,
            this.SettingToolStripMenuItem,
            this.toolStripSeparator3,
            this.TopToolStripMenuItem,
            this.TailToolStripMenuItem});
			this.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem";
			this.ViewToolStripMenuItem.Size = new System.Drawing.Size(62, 22);
			this.ViewToolStripMenuItem.Text = "表示(&V)";
			// 
			// ToolBarToolStripMenuItem
			// 
			this.ToolBarToolStripMenuItem.Checked = true;
			this.ToolBarToolStripMenuItem.CheckOnClick = true;
			this.ToolBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ToolBarToolStripMenuItem.Name = "ToolBarToolStripMenuItem";
			this.ToolBarToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
			this.ToolBarToolStripMenuItem.Text = "ツールバー";
			this.ToolBarToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.ToolBarToolStripMenuItem_CheckStateChanged);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(249, 6);
			// 
			// SettingToolStripMenuItem
			// 
			this.SettingToolStripMenuItem.Name = "SettingToolStripMenuItem";
			this.SettingToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
			this.SettingToolStripMenuItem.Text = "設定(&S)...";
			this.SettingToolStripMenuItem.Click += new System.EventHandler(this.SettingToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(249, 6);
			// 
			// TopToolStripMenuItem
			// 
			this.TopToolStripMenuItem.Enabled = false;
			this.TopToolStripMenuItem.Name = "TopToolStripMenuItem";
			this.TopToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Home)));
			this.TopToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
			this.TopToolStripMenuItem.Text = "ファイルの先頭(&T)";
			this.TopToolStripMenuItem.Click += new System.EventHandler(this.TopToolStripMenuItem_Click);
			// 
			// TailToolStripMenuItem
			// 
			this.TailToolStripMenuItem.Enabled = false;
			this.TailToolStripMenuItem.Name = "TailToolStripMenuItem";
			this.TailToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.End)));
			this.TailToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
			this.TailToolStripMenuItem.Text = "ファイルの終端(&E)";
			this.TailToolStripMenuItem.Click += new System.EventHandler(this.TailToolStripMenuItem_Click);
			// 
			// HelpToolStripMenuItem
			// 
			this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem});
			this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
			this.HelpToolStripMenuItem.Size = new System.Drawing.Size(75, 22);
			this.HelpToolStripMenuItem.Text = "ヘルプ(&H)";
			// 
			// AboutToolStripMenuItem
			// 
			this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
			this.AboutToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.AboutToolStripMenuItem.Text = "WavAnについて(&A)";
			this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
			// 
			// tabControlMain
			// 
			this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControlMain.Controls.Add(this.tabPageControl);
			this.tabControlMain.Controls.Add(this.tabPageHeader);
			this.tabControlMain.Controls.Add(this.tabPageHeaderEx);
			this.tabControlMain.Location = new System.Drawing.Point(372, 4);
			this.tabControlMain.Name = "tabControlMain";
			this.tabControlMain.SelectedIndex = 0;
			this.tabControlMain.Size = new System.Drawing.Size(258, 303);
			this.tabControlMain.TabIndex = 3;
			// 
			// tabPageControl
			// 
			this.tabPageControl.Controls.Add(this.label8);
			this.tabPageControl.Controls.Add(this.textBoxFrame);
			this.tabPageControl.Controls.Add(this.textBoxOffset);
			this.tabPageControl.Controls.Add(this.label7);
			this.tabPageControl.Location = new System.Drawing.Point(4, 22);
			this.tabPageControl.Name = "tabPageControl";
			this.tabPageControl.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageControl.Size = new System.Drawing.Size(250, 277);
			this.tabPageControl.TabIndex = 0;
			this.tabPageControl.Text = "詳細";
			this.tabPageControl.UseVisualStyleBackColor = true;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(6, 35);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(42, 12);
			this.label8.TabIndex = 3;
			this.label8.Text = "フレーム";
			// 
			// textBoxFrame
			// 
			this.textBoxFrame.Location = new System.Drawing.Point(86, 32);
			this.textBoxFrame.Name = "textBoxFrame";
			this.textBoxFrame.ReadOnly = true;
			this.textBoxFrame.Size = new System.Drawing.Size(158, 19);
			this.textBoxFrame.TabIndex = 2;
			// 
			// textBoxOffset
			// 
			this.textBoxOffset.Location = new System.Drawing.Point(86, 6);
			this.textBoxOffset.Name = "textBoxOffset";
			this.textBoxOffset.ReadOnly = true;
			this.textBoxOffset.Size = new System.Drawing.Size(158, 19);
			this.textBoxOffset.TabIndex = 1;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 10);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(74, 12);
			this.label7.TabIndex = 0;
			this.label7.Text = "バイトオフセット";
			// 
			// tabPageHeader
			// 
			this.tabPageHeader.Controls.Add(this.groupBox1);
			this.tabPageHeader.Location = new System.Drawing.Point(4, 22);
			this.tabPageHeader.Name = "tabPageHeader";
			this.tabPageHeader.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageHeader.Size = new System.Drawing.Size(250, 277);
			this.tabPageHeader.TabIndex = 1;
			this.tabPageHeader.Text = "ヘッダー(1)";
			this.tabPageHeader.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textBoxQbit);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.textBoxBlockSize);
			this.groupBox1.Controls.Add(this.textBoxFormatTag);
			this.groupBox1.Controls.Add(this.textBoxByteRate);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.textBoxChannels);
			this.groupBox1.Controls.Add(this.textBoxFs);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Location = new System.Drawing.Point(3, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(241, 173);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "WavFormat";
			// 
			// textBoxQbit
			// 
			this.textBoxQbit.Location = new System.Drawing.Point(98, 144);
			this.textBoxQbit.Name = "textBoxQbit";
			this.textBoxQbit.ReadOnly = true;
			this.textBoxQbit.Size = new System.Drawing.Size(137, 19);
			this.textBoxQbit.TabIndex = 10;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(7, 147);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(76, 12);
			this.label6.TabIndex = 11;
			this.label6.Text = "量子化ビット数";
			// 
			// textBoxBlockSize
			// 
			this.textBoxBlockSize.Location = new System.Drawing.Point(98, 119);
			this.textBoxBlockSize.Name = "textBoxBlockSize";
			this.textBoxBlockSize.ReadOnly = true;
			this.textBoxBlockSize.Size = new System.Drawing.Size(137, 19);
			this.textBoxBlockSize.TabIndex = 8;
			// 
			// textBoxFormatTag
			// 
			this.textBoxFormatTag.Location = new System.Drawing.Point(98, 18);
			this.textBoxFormatTag.Name = "textBoxFormatTag";
			this.textBoxFormatTag.ReadOnly = true;
			this.textBoxFormatTag.Size = new System.Drawing.Size(137, 19);
			this.textBoxFormatTag.TabIndex = 1;
			// 
			// textBoxByteRate
			// 
			this.textBoxByteRate.Location = new System.Drawing.Point(98, 93);
			this.textBoxByteRate.Name = "textBoxByteRate";
			this.textBoxByteRate.ReadOnly = true;
			this.textBoxByteRate.Size = new System.Drawing.Size(137, 19);
			this.textBoxByteRate.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "FormatTag";
			// 
			// textBoxChannels
			// 
			this.textBoxChannels.Location = new System.Drawing.Point(98, 43);
			this.textBoxChannels.Name = "textBoxChannels";
			this.textBoxChannels.ReadOnly = true;
			this.textBoxChannels.Size = new System.Drawing.Size(137, 19);
			this.textBoxChannels.TabIndex = 3;
			// 
			// textBoxFs
			// 
			this.textBoxFs.Location = new System.Drawing.Point(98, 68);
			this.textBoxFs.Name = "textBoxFs";
			this.textBoxFs.ReadOnly = true;
			this.textBoxFs.Size = new System.Drawing.Size(137, 19);
			this.textBoxFs.TabIndex = 4;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(7, 122);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(67, 12);
			this.label5.TabIndex = 9;
			this.label5.Text = "ブロックサイズ";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "チャンネル数";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(7, 71);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(85, 12);
			this.label3.TabIndex = 5;
			this.label3.Text = "サンプリングレート";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(59, 12);
			this.label4.TabIndex = 7;
			this.label4.Text = "バイトレート";
			// 
			// tabPageHeaderEx
			// 
			this.tabPageHeaderEx.Controls.Add(this.groupBox2);
			this.tabPageHeaderEx.Location = new System.Drawing.Point(4, 22);
			this.tabPageHeaderEx.Name = "tabPageHeaderEx";
			this.tabPageHeaderEx.Size = new System.Drawing.Size(250, 277);
			this.tabPageHeaderEx.TabIndex = 2;
			this.tabPageHeaderEx.Text = "ヘッダー(2)";
			this.tabPageHeaderEx.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.groupBox3);
			this.groupBox2.Controls.Add(this.textBoxGUID);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.labelSamples);
			this.groupBox2.Controls.Add(this.textBoxSamples);
			this.groupBox2.Location = new System.Drawing.Point(3, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(242, 271);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "WaveFormatExtensible";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.cBTopBackCenter);
			this.groupBox3.Controls.Add(this.cBTopFrontCenter);
			this.groupBox3.Controls.Add(this.cBTopBackRight);
			this.groupBox3.Controls.Add(this.cBTopBackLeft);
			this.groupBox3.Controls.Add(this.cBTopCenter);
			this.groupBox3.Controls.Add(this.cBTopFrontRight);
			this.groupBox3.Controls.Add(this.cBTopFrontLeft);
			this.groupBox3.Controls.Add(this.cBFrontRightOfCenter);
			this.groupBox3.Controls.Add(this.cBFrontLeftOfCenter);
			this.groupBox3.Controls.Add(this.cBReserved);
			this.groupBox3.Controls.Add(this.cBSideRight);
			this.groupBox3.Controls.Add(this.cBSideLeft);
			this.groupBox3.Controls.Add(this.cBBackCenter);
			this.groupBox3.Controls.Add(this.cBBackRight);
			this.groupBox3.Controls.Add(this.cBBackLeft);
			this.groupBox3.Controls.Add(this.cBLowFreq);
			this.groupBox3.Controls.Add(this.cBFrontCenter);
			this.groupBox3.Controls.Add(this.cBFrontRight);
			this.groupBox3.Controls.Add(this.cBFrontLeft);
			this.groupBox3.Location = new System.Drawing.Point(8, 68);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(228, 197);
			this.groupBox3.TabIndex = 6;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "チャンネルアサイン";
			// 
			// cBTopBackCenter
			// 
			this.cBTopBackCenter.AutoSize = true;
			this.cBTopBackCenter.Enabled = false;
			this.cBTopBackCenter.Location = new System.Drawing.Point(117, 172);
			this.cBTopBackCenter.Name = "cBTopBackCenter";
			this.cBTopBackCenter.Size = new System.Drawing.Size(111, 16);
			this.cBTopBackCenter.TabIndex = 18;
			this.cBTopBackCenter.Text = "Top Back Center";
			this.cBTopBackCenter.UseVisualStyleBackColor = true;
			// 
			// cBTopFrontCenter
			// 
			this.cBTopFrontCenter.AutoSize = true;
			this.cBTopFrontCenter.Enabled = false;
			this.cBTopFrontCenter.Location = new System.Drawing.Point(6, 172);
			this.cBTopFrontCenter.Name = "cBTopFrontCenter";
			this.cBTopFrontCenter.Size = new System.Drawing.Size(112, 16);
			this.cBTopFrontCenter.TabIndex = 17;
			this.cBTopFrontCenter.Text = "Top Front Center";
			this.cBTopFrontCenter.UseVisualStyleBackColor = true;
			// 
			// cBTopBackRight
			// 
			this.cBTopBackRight.AutoSize = true;
			this.cBTopBackRight.Enabled = false;
			this.cBTopBackRight.Location = new System.Drawing.Point(117, 150);
			this.cBTopBackRight.Name = "cBTopBackRight";
			this.cBTopBackRight.Size = new System.Drawing.Size(104, 16);
			this.cBTopBackRight.TabIndex = 16;
			this.cBTopBackRight.Text = "Top Back Right";
			this.cBTopBackRight.UseVisualStyleBackColor = true;
			// 
			// cBTopBackLeft
			// 
			this.cBTopBackLeft.AutoSize = true;
			this.cBTopBackLeft.Enabled = false;
			this.cBTopBackLeft.Location = new System.Drawing.Point(6, 150);
			this.cBTopBackLeft.Name = "cBTopBackLeft";
			this.cBTopBackLeft.Size = new System.Drawing.Size(97, 16);
			this.cBTopBackLeft.TabIndex = 15;
			this.cBTopBackLeft.Text = "Top Back Left";
			this.cBTopBackLeft.UseVisualStyleBackColor = true;
			// 
			// cBTopCenter
			// 
			this.cBTopCenter.AutoSize = true;
			this.cBTopCenter.Enabled = false;
			this.cBTopCenter.Location = new System.Drawing.Point(96, 62);
			this.cBTopCenter.Name = "cBTopCenter";
			this.cBTopCenter.Size = new System.Drawing.Size(81, 16);
			this.cBTopCenter.TabIndex = 14;
			this.cBTopCenter.Text = "Top Center";
			this.cBTopCenter.UseVisualStyleBackColor = true;
			// 
			// cBTopFrontRight
			// 
			this.cBTopFrontRight.AutoSize = true;
			this.cBTopFrontRight.Enabled = false;
			this.cBTopFrontRight.Location = new System.Drawing.Point(117, 128);
			this.cBTopFrontRight.Name = "cBTopFrontRight";
			this.cBTopFrontRight.Size = new System.Drawing.Size(105, 16);
			this.cBTopFrontRight.TabIndex = 13;
			this.cBTopFrontRight.Text = "Top Front Right";
			this.cBTopFrontRight.UseVisualStyleBackColor = true;
			// 
			// cBTopFrontLeft
			// 
			this.cBTopFrontLeft.AutoSize = true;
			this.cBTopFrontLeft.Enabled = false;
			this.cBTopFrontLeft.Location = new System.Drawing.Point(6, 128);
			this.cBTopFrontLeft.Name = "cBTopFrontLeft";
			this.cBTopFrontLeft.Size = new System.Drawing.Size(98, 16);
			this.cBTopFrontLeft.TabIndex = 12;
			this.cBTopFrontLeft.Text = "Top Front Left";
			this.cBTopFrontLeft.UseVisualStyleBackColor = true;
			// 
			// cBFrontRightOfCenter
			// 
			this.cBFrontRightOfCenter.AutoSize = true;
			this.cBFrontRightOfCenter.Enabled = false;
			this.cBFrontRightOfCenter.Location = new System.Drawing.Point(6, 106);
			this.cBFrontRightOfCenter.Name = "cBFrontRightOfCenter";
			this.cBFrontRightOfCenter.Size = new System.Drawing.Size(134, 16);
			this.cBFrontRightOfCenter.TabIndex = 11;
			this.cBFrontRightOfCenter.Text = "Front Right of Center";
			this.cBFrontRightOfCenter.UseVisualStyleBackColor = true;
			// 
			// cBFrontLeftOfCenter
			// 
			this.cBFrontLeftOfCenter.AutoSize = true;
			this.cBFrontLeftOfCenter.Enabled = false;
			this.cBFrontLeftOfCenter.Location = new System.Drawing.Point(6, 84);
			this.cBFrontLeftOfCenter.Name = "cBFrontLeftOfCenter";
			this.cBFrontLeftOfCenter.Size = new System.Drawing.Size(127, 16);
			this.cBFrontLeftOfCenter.TabIndex = 10;
			this.cBFrontLeftOfCenter.Text = "Front Left of Center";
			this.cBFrontLeftOfCenter.UseVisualStyleBackColor = true;
			// 
			// cBReserved
			// 
			this.cBReserved.AutoSize = true;
			this.cBReserved.Enabled = false;
			this.cBReserved.Location = new System.Drawing.Point(6, 62);
			this.cBReserved.Name = "cBReserved";
			this.cBReserved.Size = new System.Drawing.Size(72, 16);
			this.cBReserved.TabIndex = 9;
			this.cBReserved.Text = "Reserved";
			this.cBReserved.UseVisualStyleBackColor = true;
			// 
			// cBSideRight
			// 
			this.cBSideRight.AutoSize = true;
			this.cBSideRight.Enabled = false;
			this.cBSideRight.Location = new System.Drawing.Point(183, 40);
			this.cBSideRight.Name = "cBSideRight";
			this.cBSideRight.Size = new System.Drawing.Size(39, 16);
			this.cBSideRight.TabIndex = 8;
			this.cBSideRight.Text = "SR";
			this.cBSideRight.UseVisualStyleBackColor = true;
			// 
			// cBSideLeft
			// 
			this.cBSideLeft.AutoSize = true;
			this.cBSideLeft.Enabled = false;
			this.cBSideLeft.Location = new System.Drawing.Point(142, 40);
			this.cBSideLeft.Name = "cBSideLeft";
			this.cBSideLeft.Size = new System.Drawing.Size(37, 16);
			this.cBSideLeft.TabIndex = 7;
			this.cBSideLeft.Text = "SL";
			this.cBSideLeft.UseVisualStyleBackColor = true;
			// 
			// cBBackCenter
			// 
			this.cBBackCenter.AutoSize = true;
			this.cBBackCenter.Enabled = false;
			this.cBBackCenter.Location = new System.Drawing.Point(96, 40);
			this.cBBackCenter.Name = "cBBackCenter";
			this.cBBackCenter.Size = new System.Drawing.Size(40, 16);
			this.cBBackCenter.TabIndex = 6;
			this.cBBackCenter.Text = "BC";
			this.cBBackCenter.UseVisualStyleBackColor = true;
			// 
			// cBBackRight
			// 
			this.cBBackRight.AutoSize = true;
			this.cBBackRight.Enabled = false;
			this.cBBackRight.Location = new System.Drawing.Point(50, 40);
			this.cBBackRight.Name = "cBBackRight";
			this.cBBackRight.Size = new System.Drawing.Size(40, 16);
			this.cBBackRight.TabIndex = 5;
			this.cBBackRight.Text = "BR";
			this.cBBackRight.UseVisualStyleBackColor = true;
			// 
			// cBBackLeft
			// 
			this.cBBackLeft.AutoSize = true;
			this.cBBackLeft.Enabled = false;
			this.cBBackLeft.Location = new System.Drawing.Point(6, 40);
			this.cBBackLeft.Name = "cBBackLeft";
			this.cBBackLeft.Size = new System.Drawing.Size(38, 16);
			this.cBBackLeft.TabIndex = 4;
			this.cBBackLeft.Text = "BL";
			this.cBBackLeft.UseVisualStyleBackColor = true;
			// 
			// cBLowFreq
			// 
			this.cBLowFreq.AutoSize = true;
			this.cBLowFreq.Enabled = false;
			this.cBLowFreq.Location = new System.Drawing.Point(139, 18);
			this.cBLowFreq.Name = "cBLowFreq";
			this.cBLowFreq.Size = new System.Drawing.Size(44, 16);
			this.cBLowFreq.TabIndex = 3;
			this.cBLowFreq.Text = "LFE";
			this.cBLowFreq.UseVisualStyleBackColor = true;
			// 
			// cBFrontCenter
			// 
			this.cBFrontCenter.AutoSize = true;
			this.cBFrontCenter.Enabled = false;
			this.cBFrontCenter.Location = new System.Drawing.Point(96, 18);
			this.cBFrontCenter.Name = "cBFrontCenter";
			this.cBFrontCenter.Size = new System.Drawing.Size(32, 16);
			this.cBFrontCenter.TabIndex = 2;
			this.cBFrontCenter.Text = "C";
			this.cBFrontCenter.UseVisualStyleBackColor = true;
			// 
			// cBFrontRight
			// 
			this.cBFrontRight.AutoSize = true;
			this.cBFrontRight.Enabled = false;
			this.cBFrontRight.Location = new System.Drawing.Point(50, 18);
			this.cBFrontRight.Name = "cBFrontRight";
			this.cBFrontRight.Size = new System.Drawing.Size(39, 16);
			this.cBFrontRight.TabIndex = 1;
			this.cBFrontRight.Text = "FR";
			this.cBFrontRight.UseVisualStyleBackColor = true;
			// 
			// cBFrontLeft
			// 
			this.cBFrontLeft.AutoSize = true;
			this.cBFrontLeft.Enabled = false;
			this.cBFrontLeft.Location = new System.Drawing.Point(6, 18);
			this.cBFrontLeft.Name = "cBFrontLeft";
			this.cBFrontLeft.Size = new System.Drawing.Size(37, 16);
			this.cBFrontLeft.TabIndex = 0;
			this.cBFrontLeft.Text = "FL";
			this.cBFrontLeft.UseVisualStyleBackColor = true;
			// 
			// textBoxGUID
			// 
			this.textBoxGUID.Location = new System.Drawing.Point(122, 43);
			this.textBoxGUID.Name = "textBoxGUID";
			this.textBoxGUID.ReadOnly = true;
			this.textBoxGUID.Size = new System.Drawing.Size(114, 19);
			this.textBoxGUID.TabIndex = 5;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(6, 46);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(32, 12);
			this.label9.TabIndex = 4;
			this.label9.Text = "GUID";
			// 
			// labelSamples
			// 
			this.labelSamples.AutoSize = true;
			this.labelSamples.Location = new System.Drawing.Point(6, 21);
			this.labelSamples.Name = "labelSamples";
			this.labelSamples.Size = new System.Drawing.Size(110, 12);
			this.labelSamples.TabIndex = 3;
			this.labelSamples.Text = "ブロック毎のサンプル数";
			// 
			// textBoxSamples
			// 
			this.textBoxSamples.Location = new System.Drawing.Point(122, 18);
			this.textBoxSamples.Name = "textBoxSamples";
			this.textBoxSamples.ReadOnly = true;
			this.textBoxSamples.Size = new System.Drawing.Size(114, 19);
			this.textBoxSamples.TabIndex = 2;
			// 
			// openFD
			// 
			this.openFD.Filter = "Wavファイル|*.wav|すべてのファイル|*.*";
			this.openFD.Title = "解析ファイルの選択";
			// 
			// rTBMain
			// 
			this.rTBMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.rTBMain.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.rTBMain.Location = new System.Drawing.Point(12, 4);
			this.rTBMain.Name = "rTBMain";
			this.rTBMain.ReadOnly = true;
			this.rTBMain.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.rTBMain.Size = new System.Drawing.Size(354, 303);
			this.rTBMain.TabIndex = 4;
			this.rTBMain.Text = "";
			// 
			// toolStripContainerMain
			// 
			this.toolStripContainerMain.BottomToolStripPanelVisible = false;
			// 
			// toolStripContainerMain.ContentPanel
			// 
			this.toolStripContainerMain.ContentPanel.Controls.Add(this.rTBMain);
			this.toolStripContainerMain.ContentPanel.Controls.Add(this.tabControlMain);
			this.toolStripContainerMain.ContentPanel.Size = new System.Drawing.Size(633, 314);
			this.toolStripContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainerMain.LeftToolStripPanelVisible = false;
			this.toolStripContainerMain.Location = new System.Drawing.Point(0, 26);
			this.toolStripContainerMain.Name = "toolStripContainerMain";
			this.toolStripContainerMain.RightToolStripPanelVisible = false;
			this.toolStripContainerMain.Size = new System.Drawing.Size(633, 340);
			this.toolStripContainerMain.TabIndex = 6;
			this.toolStripContainerMain.Text = "toolStripContainer1";
			// 
			// toolStripContainerMain.TopToolStripPanel
			// 
			this.toolStripContainerMain.TopToolStripPanel.Controls.Add(this.toolStripMain);
			// 
			// toolStripMain
			// 
			this.toolStripMain.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonOpen,
            this.toolStripSeparator1,
            this.toolStripCBDisp,
            this.toolStripButtonPrev,
            this.toolStripButtonPrevL,
            this.toolStripButtonNextL,
            this.toolStripButtonNext});
			this.toolStripMain.Location = new System.Drawing.Point(3, 0);
			this.toolStripMain.Name = "toolStripMain";
			this.toolStripMain.Size = new System.Drawing.Size(237, 26);
			this.toolStripMain.TabIndex = 0;
			// 
			// toolStripButtonOpen
			// 
			this.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOpen.Image")));
			this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonOpen.Name = "toolStripButtonOpen";
			this.toolStripButtonOpen.Size = new System.Drawing.Size(23, 23);
			this.toolStripButtonOpen.Text = "toolStripButton1";
			this.toolStripButtonOpen.Click += new System.EventHandler(this.toolStripButtonOpen_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
			// 
			// toolStripCBDisp
			// 
			this.toolStripCBDisp.Items.AddRange(new object[] {
            "8bit",
            "16bit",
            "24bit",
            "32bit"});
			this.toolStripCBDisp.Name = "toolStripCBDisp";
			this.toolStripCBDisp.Size = new System.Drawing.Size(84, 26);
			this.toolStripCBDisp.SelectedIndexChanged += new System.EventHandler(this.toolStripCBDisp_SelectedIndexChanged);
			// 
			// toolStripButtonPrev
			// 
			this.toolStripButtonPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButtonPrev.Enabled = false;
			this.toolStripButtonPrev.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPrev.Image")));
			this.toolStripButtonPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonPrev.Name = "toolStripButtonPrev";
			this.toolStripButtonPrev.Size = new System.Drawing.Size(23, 23);
			this.toolStripButtonPrev.Text = "<";
			this.toolStripButtonPrev.Click += new System.EventHandler(this.toolStripButtonPrev_Click);
			// 
			// toolStripButtonPrevL
			// 
			this.toolStripButtonPrevL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButtonPrevL.Enabled = false;
			this.toolStripButtonPrevL.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPrevL.Image")));
			this.toolStripButtonPrevL.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonPrevL.Name = "toolStripButtonPrevL";
			this.toolStripButtonPrevL.Size = new System.Drawing.Size(32, 23);
			this.toolStripButtonPrevL.Text = "<<";
			this.toolStripButtonPrevL.Click += new System.EventHandler(this.toolStripButtonPrevL_Click);
			// 
			// toolStripButtonNextL
			// 
			this.toolStripButtonNextL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButtonNextL.Enabled = false;
			this.toolStripButtonNextL.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNextL.Image")));
			this.toolStripButtonNextL.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonNextL.Name = "toolStripButtonNextL";
			this.toolStripButtonNextL.Size = new System.Drawing.Size(32, 23);
			this.toolStripButtonNextL.Text = ">>";
			this.toolStripButtonNextL.Click += new System.EventHandler(this.toolStripButtonNextL_Click);
			// 
			// toolStripButtonNext
			// 
			this.toolStripButtonNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButtonNext.Enabled = false;
			this.toolStripButtonNext.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNext.Image")));
			this.toolStripButtonNext.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonNext.Name = "toolStripButtonNext";
			this.toolStripButtonNext.Size = new System.Drawing.Size(23, 23);
			this.toolStripButtonNext.Text = ">";
			this.toolStripButtonNext.Click += new System.EventHandler(this.toolStripButtonNext_Click);
			// 
			// MainForm
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(633, 366);
			this.Controls.Add(this.toolStripContainerMain);
			this.Controls.Add(this.MainMenu);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.MainMenu;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "WavAn";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.MainMenu.ResumeLayout(false);
			this.MainMenu.PerformLayout();
			this.tabControlMain.ResumeLayout(false);
			this.tabPageControl.ResumeLayout(false);
			this.tabPageControl.PerformLayout();
			this.tabPageHeader.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabPageHeaderEx.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.toolStripContainerMain.ContentPanel.ResumeLayout(false);
			this.toolStripContainerMain.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainerMain.TopToolStripPanel.PerformLayout();
			this.toolStripContainerMain.ResumeLayout(false);
			this.toolStripContainerMain.PerformLayout();
			this.toolStripMain.ResumeLayout(false);
			this.toolStripMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageControl;
        private System.Windows.Forms.TabPage tabPageHeader;
        private System.Windows.Forms.OpenFileDialog openFD;
		private System.Windows.Forms.TextBox textBoxFormatTag;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxChannels;
		private System.Windows.Forms.TextBox textBoxFs;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxByteRate;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxBlockSize;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBoxQbit;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBoxOffset;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.RichTextBox rTBMain;
		private System.Windows.Forms.ToolStripContainer toolStripContainerMain;
		private System.Windows.Forms.ToolStrip toolStripMain;
		private System.Windows.Forms.ToolStripComboBox toolStripCBDisp;
		private System.Windows.Forms.ToolStripButton toolStripButtonPrev;
		private System.Windows.Forms.ToolStripMenuItem ViewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ToolBarToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton toolStripButtonPrevL;
		private System.Windows.Forms.ToolStripButton toolStripButtonNextL;
		private System.Windows.Forms.ToolStripButton toolStripButtonNext;
		private System.Windows.Forms.ToolStripButton toolStripButtonOpen;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem SettingToolStripMenuItem;
		private System.Windows.Forms.TextBox textBoxFrame;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem TopToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem TailToolStripMenuItem;
		private System.Windows.Forms.TabPage tabPageHeaderEx;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox textBoxSamples;
		private System.Windows.Forms.Label labelSamples;
		private System.Windows.Forms.TextBox textBoxGUID;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox cBFrontLeft;
		private System.Windows.Forms.CheckBox cBFrontRight;
		private System.Windows.Forms.CheckBox cBFrontCenter;
		private System.Windows.Forms.CheckBox cBLowFreq;
		private System.Windows.Forms.CheckBox cBBackLeft;
		private System.Windows.Forms.CheckBox cBBackRight;
		private System.Windows.Forms.CheckBox cBBackCenter;
		private System.Windows.Forms.CheckBox cBSideLeft;
		private System.Windows.Forms.CheckBox cBSideRight;
		private System.Windows.Forms.CheckBox cBReserved;
		private System.Windows.Forms.CheckBox cBFrontLeftOfCenter;
		private System.Windows.Forms.CheckBox cBFrontRightOfCenter;
		private System.Windows.Forms.CheckBox cBTopFrontLeft;
		private System.Windows.Forms.CheckBox cBTopFrontRight;
		private System.Windows.Forms.CheckBox cBTopCenter;
		private System.Windows.Forms.CheckBox cBTopBackLeft;
		private System.Windows.Forms.CheckBox cBTopBackRight;
		private System.Windows.Forms.CheckBox cBTopFrontCenter;
		private System.Windows.Forms.CheckBox cBTopBackCenter;
    }
}

