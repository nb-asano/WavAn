namespace WavAn
{
	partial class SettingForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cBDispColor = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rBMoveFrame = new System.Windows.Forms.RadioButton();
			this.rBMoveByte = new System.Windows.Forms.RadioButton();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.rBFromStreamTop = new System.Windows.Forms.RadioButton();
			this.rBFromFileTop = new System.Windows.Forms.RadioButton();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.rB8bit = new System.Windows.Forms.RadioButton();
			this.rB16bit = new System.Windows.Forms.RadioButton();
			this.rB24bit = new System.Windows.Forms.RadioButton();
			this.rB32bit = new System.Windows.Forms.RadioButton();
			this.cBUsingStreamQbit = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// cBDispColor
			// 
			this.cBDispColor.AutoSize = true;
			this.cBDispColor.Location = new System.Drawing.Point(12, 12);
			this.cBDispColor.Name = "cBDispColor";
			this.cBDispColor.Size = new System.Drawing.Size(172, 16);
			this.cBDispColor.TabIndex = 0;
			this.cBDispColor.Text = "チャンネルごとに色分けして表示";
			this.cBDispColor.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.rBMoveByte);
			this.groupBox1.Controls.Add(this.rBMoveFrame);
			this.groupBox1.Location = new System.Drawing.Point(12, 62);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(320, 44);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "移動単位";
			// 
			// rBMoveFrame
			// 
			this.rBMoveFrame.AutoSize = true;
			this.rBMoveFrame.Location = new System.Drawing.Point(6, 18);
			this.rBMoveFrame.Name = "rBMoveFrame";
			this.rBMoveFrame.Size = new System.Drawing.Size(84, 16);
			this.rBMoveFrame.TabIndex = 0;
			this.rBMoveFrame.TabStop = true;
			this.rBMoveFrame.Text = "フレーム単位";
			this.rBMoveFrame.UseVisualStyleBackColor = true;
			// 
			// rBMoveByte
			// 
			this.rBMoveByte.AutoSize = true;
			this.rBMoveByte.Location = new System.Drawing.Point(107, 18);
			this.rBMoveByte.Name = "rBMoveByte";
			this.rBMoveByte.Size = new System.Drawing.Size(74, 16);
			this.rBMoveByte.TabIndex = 1;
			this.rBMoveByte.TabStop = true;
			this.rBMoveByte.Text = "バイト単位";
			this.rBMoveByte.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(176, 216);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(257, 216);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.rBFromFileTop);
			this.groupBox2.Controls.Add(this.rBFromStreamTop);
			this.groupBox2.Location = new System.Drawing.Point(12, 112);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(320, 44);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "表示起点";
			// 
			// rBFromStreamTop
			// 
			this.rBFromStreamTop.AutoSize = true;
			this.rBFromStreamTop.Location = new System.Drawing.Point(6, 18);
			this.rBFromStreamTop.Name = "rBFromStreamTop";
			this.rBFromStreamTop.Size = new System.Drawing.Size(91, 16);
			this.rBFromStreamTop.TabIndex = 0;
			this.rBFromStreamTop.TabStop = true;
			this.rBFromStreamTop.Text = "ストリーム先頭";
			this.rBFromStreamTop.UseVisualStyleBackColor = true;
			// 
			// rBFromFileTop
			// 
			this.rBFromFileTop.AutoSize = true;
			this.rBFromFileTop.Location = new System.Drawing.Point(107, 18);
			this.rBFromFileTop.Name = "rBFromFileTop";
			this.rBFromFileTop.Size = new System.Drawing.Size(81, 16);
			this.rBFromFileTop.TabIndex = 1;
			this.rBFromFileTop.TabStop = true;
			this.rBFromFileTop.Text = "ファイル先頭";
			this.rBFromFileTop.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.rB32bit);
			this.groupBox3.Controls.Add(this.rB24bit);
			this.groupBox3.Controls.Add(this.rB16bit);
			this.groupBox3.Controls.Add(this.rB8bit);
			this.groupBox3.Location = new System.Drawing.Point(12, 162);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(320, 44);
			this.groupBox3.TabIndex = 5;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "表示単位";
			// 
			// rB8bit
			// 
			this.rB8bit.AutoSize = true;
			this.rB8bit.Location = new System.Drawing.Point(6, 18);
			this.rB8bit.Name = "rB8bit";
			this.rB8bit.Size = new System.Drawing.Size(42, 16);
			this.rB8bit.TabIndex = 0;
			this.rB8bit.TabStop = true;
			this.rB8bit.Text = "8bit";
			this.rB8bit.UseVisualStyleBackColor = true;
			// 
			// rB16bit
			// 
			this.rB16bit.AutoSize = true;
			this.rB16bit.Location = new System.Drawing.Point(54, 18);
			this.rB16bit.Name = "rB16bit";
			this.rB16bit.Size = new System.Drawing.Size(48, 16);
			this.rB16bit.TabIndex = 1;
			this.rB16bit.TabStop = true;
			this.rB16bit.Text = "16bit";
			this.rB16bit.UseVisualStyleBackColor = true;
			// 
			// rB24bit
			// 
			this.rB24bit.AutoSize = true;
			this.rB24bit.Location = new System.Drawing.Point(107, 18);
			this.rB24bit.Name = "rB24bit";
			this.rB24bit.Size = new System.Drawing.Size(48, 16);
			this.rB24bit.TabIndex = 2;
			this.rB24bit.TabStop = true;
			this.rB24bit.Text = "24bit";
			this.rB24bit.UseVisualStyleBackColor = true;
			// 
			// rB32bit
			// 
			this.rB32bit.AutoSize = true;
			this.rB32bit.Location = new System.Drawing.Point(162, 18);
			this.rB32bit.Name = "rB32bit";
			this.rB32bit.Size = new System.Drawing.Size(48, 16);
			this.rB32bit.TabIndex = 3;
			this.rB32bit.TabStop = true;
			this.rB32bit.Text = "32bit";
			this.rB32bit.UseVisualStyleBackColor = true;
			// 
			// cBUsingStreamQbit
			// 
			this.cBUsingStreamQbit.AutoSize = true;
			this.cBUsingStreamQbit.Location = new System.Drawing.Point(12, 35);
			this.cBUsingStreamQbit.Name = "cBUsingStreamQbit";
			this.cBUsingStreamQbit.Size = new System.Drawing.Size(223, 16);
			this.cBUsingStreamQbit.TabIndex = 6;
			this.cBUsingStreamQbit.Text = "ストリームの量子化ビット数に合わせて表示";
			this.cBUsingStreamQbit.UseVisualStyleBackColor = true;
			// 
			// SettingForm
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(344, 251);
			this.Controls.Add(this.cBUsingStreamQbit);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.cBDispColor);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "設定";
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

		private System.Windows.Forms.CheckBox cBDispColor;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rBMoveFrame;
		private System.Windows.Forms.RadioButton rBMoveByte;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rBFromStreamTop;
		private System.Windows.Forms.RadioButton rBFromFileTop;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton rB8bit;
		private System.Windows.Forms.RadioButton rB16bit;
		private System.Windows.Forms.RadioButton rB24bit;
		private System.Windows.Forms.RadioButton rB32bit;
		private System.Windows.Forms.CheckBox cBUsingStreamQbit;

	}
}