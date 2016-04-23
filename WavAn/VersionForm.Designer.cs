namespace WavAn
{
	partial class VersionForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VersionForm));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.labelVer = new System.Windows.Forms.Label();
			this.labelCopyRight = new System.Windows.Forms.Label();
			this.buttonOK = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(128, 128);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label1.Location = new System.Drawing.Point(146, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 19);
			this.label1.TabIndex = 1;
			this.label1.Text = "WavAn";
			// 
			// labelVer
			// 
			this.labelVer.AutoSize = true;
			this.labelVer.Location = new System.Drawing.Point(148, 57);
			this.labelVer.Name = "labelVer";
			this.labelVer.Size = new System.Drawing.Size(46, 12);
			this.labelVer.TabIndex = 2;
			this.labelVer.Text = "Version:";
			// 
			// labelCopyRight
			// 
			this.labelCopyRight.AutoSize = true;
			this.labelCopyRight.Location = new System.Drawing.Point(148, 75);
			this.labelCopyRight.Name = "labelCopyRight";
			this.labelCopyRight.Size = new System.Drawing.Size(19, 12);
			this.labelCopyRight.TabIndex = 3;
			this.labelCopyRight.Text = "(c)";
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(272, 117);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 4;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// VersionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(359, 153);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.labelCopyRight);
			this.Controls.Add(this.labelVer);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "VersionForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "WavAnのバージョン情報";
			this.Load += new System.EventHandler(this.VersionForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label labelVer;
		private System.Windows.Forms.Label labelCopyRight;
		private System.Windows.Forms.Button buttonOK;
	}
}