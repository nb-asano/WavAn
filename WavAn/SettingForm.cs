using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WavAn
{
	public partial class SettingForm : Form
	{
		private DisplaySetting m_Setting;

		public DisplaySetting Setting
		{
			get { return m_Setting; }
		}

		public SettingForm(DisplaySetting setting)
		{
			InitializeComponent();
			m_Setting = setting;

			// 表示を反映
			cBDispColor.Checked = m_Setting.ChannelColor;
			cBUsingStreamQbit.Checked = m_Setting.UsingStreamQbit;

			switch (m_Setting.MovingMode) {
				case MovingScale.Frame:
					rBMoveFrame.Checked = true;
					break;
				case MovingScale.Byte:
					rBMoveByte.Checked = true;
					break;
			}

			switch (m_Setting.OffsetFrom) {
				case OffsetOrigin.StreamTop:
					rBFromStreamTop.Checked = true;
					break;
				case OffsetOrigin.FileTop:
					rBFromFileTop.Checked = true;
					break;
			}

			switch (m_Setting.StreamScale) {
				case DisplayStreamScale.Bit8:
					rB8bit.Checked = true;
					break;
				case DisplayStreamScale.Bit16:
					rB16bit.Checked = true;
					break;
				case DisplayStreamScale.Bit24:
					rB24bit.Checked = true;
					break;
				case DisplayStreamScale.Bit32:
					rB32bit.Checked = true;
					break;
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			m_Setting.ChannelColor = cBDispColor.Checked;
			m_Setting.UsingStreamQbit = cBUsingStreamQbit.Checked;

			if (rBMoveFrame.Checked) {
				m_Setting.MovingMode = MovingScale.Frame;
			} else {
				m_Setting.MovingMode = MovingScale.Byte;
			}

			if (rBFromStreamTop.Checked) {
				m_Setting.OffsetFrom = OffsetOrigin.StreamTop;
			} else {
				m_Setting.OffsetFrom = OffsetOrigin.FileTop;
			}

			if (rB8bit.Checked) {
				m_Setting.StreamScale = DisplayStreamScale.Bit8;
			} else if (rB16bit.Checked) {
				m_Setting.StreamScale = DisplayStreamScale.Bit16;
			} else if (rB24bit.Checked) {
				m_Setting.StreamScale = DisplayStreamScale.Bit24;
			} else if (rB32bit.Checked) {
				m_Setting.StreamScale = DisplayStreamScale.Bit32;
			}
		}
	}
}
