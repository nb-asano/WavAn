using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace WavAn
{
	public partial class VersionForm : Form
	{
		public VersionForm()
		{
			InitializeComponent();
		}

		private void VersionForm_Load(object sender, EventArgs e)
		{
			FileVersionInfo info = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
			labelVer.Text = "バージョン：" + info.FileVersion;

			AssemblyCopyrightAttribute asmcpy
				= (AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyCopyrightAttribute));
			labelCopyRight.Text = asmcpy.Copyright;
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
