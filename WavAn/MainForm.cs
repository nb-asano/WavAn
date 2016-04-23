using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WavAn
{
    public partial class MainForm : Form
    {
        #region フィールド

        /// <summary>入力ストリーム</summary>
		private IPcmStream m_PcmStream;
		/// <summary>現在表示しているバイト列データ</summary>
		private byte[] m_DisplaySource;
		/// <summary>現在表示しているバイト列データ先頭のバイトオフセット（ファイル内実アドレス）</summary>
		private long m_DisplayPosition;
		/// <summary>表示制御情報</summary>
		private DisplayData m_DisplayData;

        #endregion

        public MainForm()
        {
            InitializeComponent();

			rTBMain.AllowDrop = true;
			rTBMain.DragEnter += new DragEventHandler(this.RichTextBoxMain_DragEnter);
			rTBMain.DragDrop += new DragEventHandler(this.RichTextBoxMain_DragDrop);
			toolStripContainerMain.TopToolStripPanelVisible = ToolBarToolStripMenuItem.Checked;
			toolStripCBDisp.SelectedIndex = 0;

			m_DisplayData = new DisplayData();
        }

		#region イベントハンドラ

		private void MainForm_Load(object sender, EventArgs e)
		{
			calcMainRtbMaxLine();
			m_DisplayData.ReadSize = m_DisplayData.MaxLine * 16;

			// コマンドラインを配列で取得
			string[] cmds = System.Environment.GetCommandLineArgs();

			if (cmds.Length > 1) {
				openPcm(cmds[1]);
				m_DisplaySource = m_PcmStream.Read(m_DisplayData.ReadSize);
				m_DisplayPosition = m_PcmStream.CurrentPos - m_DisplayData.ReadSize;
				showData(m_DisplaySource, m_DisplayPosition, m_PcmStream.StreamOffset, m_PcmStream.WaveFormat);
			} else {
				showData(m_DisplaySource, m_DisplayPosition, 0, new WaveFormatEx());
			}
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (m_PcmStream != null) {
				m_PcmStream.Close();
			}
		}

		private void RichTextBoxMain_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
				e.Effect = DragDropEffects.Copy;
			} else {
				e.Effect = DragDropEffects.None;
			}
		}

		private void RichTextBoxMain_DragDrop(object sender, DragEventArgs e)
		{
			string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			if (fileNames.Length > 0) {
				openPcm(fileNames[0]);
			}
		}

		#endregion

		#region メニューのイベントハンドラ

		/// <summary>
		/// ファイル→開く
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = openFD.ShowDialog();
            if (res == DialogResult.OK) {
				openPcm(openFD.FileName);
				m_DisplaySource = m_PcmStream.Read(m_DisplayData.ReadSize);
				m_DisplayPosition = m_PcmStream.CurrentPos - m_DisplayData.ReadSize;
				showData(m_DisplaySource, m_DisplayPosition, m_PcmStream.StreamOffset, m_PcmStream.WaveFormat);
            }
        }
		/// <summary>
		/// ファイル→閉じる
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
			closePcm();
        }
		/// <summary>
		/// ファイル→終了
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
		/// <summary>
		/// 表示→ツールバー
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ToolBarToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
		{
			toolStripContainerMain.TopToolStripPanelVisible = ToolBarToolStripMenuItem.Checked;
		}
		/// <summary>
		/// 表示→設定
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SettingToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SettingForm s = new SettingForm(m_DisplayData.Setting);
			DialogResult ret = s.ShowDialog();
			if (ret == DialogResult.OK) {
				refreshMain();
			}
			s.Dispose();
		}

		private void TopToolStripMenuItem_Click(object sender, EventArgs e)
		{
			m_PcmStream.SeekStream(0, SeekOrigin.Begin);
			m_DisplaySource = m_PcmStream.Read(m_DisplayData.ReadSize);
			m_DisplayPosition = m_PcmStream.CurrentPos - m_DisplayData.ReadSize;
			showData(m_DisplaySource, m_DisplayPosition, m_PcmStream.StreamOffset, m_PcmStream.WaveFormat);
		}

		private void TailToolStripMenuItem_Click(object sender, EventArgs e)
		{
			m_PcmStream.SeekStream(m_PcmStream.Length - m_DisplayData.ReadSize, SeekOrigin.Begin);
			m_DisplaySource = m_PcmStream.Read(m_DisplayData.ReadSize);
			m_DisplayPosition = m_PcmStream.CurrentPos - m_DisplayData.ReadSize;
			showData(m_DisplaySource, m_DisplayPosition, m_PcmStream.StreamOffset, m_PcmStream.WaveFormat);
		}
		/// <summary>
		/// ヘルプ→WavAnについて
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
			VersionForm form = new VersionForm();
			form.ShowDialog();
        }

        #endregion

		#region ToolBarのイベントハンドラ

		/// <summary>
		/// 前方移動ボタンクリック時のイベントハンドラ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void toolStripButtonPrev_Click(object sender, EventArgs e)
		{
			int n = getMoveOrder();

			// 先頭にいれば何もしない
			if (m_DisplayPosition <= 0) {
				return;
			} else if (m_DisplayPosition <= n) {
				// 先頭に到達する場合は先頭へ
				m_PcmStream.SeekStream(0, SeekOrigin.Begin);
				m_DisplaySource = m_PcmStream.Read(m_DisplayData.ReadSize);
				m_DisplayPosition = m_PcmStream.CurrentPos - m_DisplayData.ReadSize;
				showData(m_DisplaySource, m_DisplayPosition, m_PcmStream.StreamOffset, m_PcmStream.WaveFormat);
			} else {
				// nバイトだけ読みだしてずらす
				byte[] tmp = m_DisplaySource;
				m_PcmStream.SeekStream(m_DisplayPosition - n, SeekOrigin.Begin);
				byte[] prev = m_PcmStream.Read(n);
				m_DisplaySource = new byte[tmp.Length];
				Array.Copy(prev, 0, m_DisplaySource, 0, n);
				Array.Copy(tmp, 0, m_DisplaySource, n, tmp.Length - n);
				m_DisplayPosition -= n;
				showData(m_DisplaySource, m_DisplayPosition, m_PcmStream.StreamOffset, m_PcmStream.WaveFormat);
			}
		}
		/// <summary>
		/// 前方移動（大）ボタンクリック時のイベントハンドラ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void toolStripButtonPrevL_Click(object sender, EventArgs e)
		{
			int n = getMoveOrder();
			int size = (m_DisplayData.ReadSize / n) * n;

			// 先頭にいれば何もしない
			if (m_DisplayPosition <= 0) {
				return;
			} else if (m_DisplayPosition <= size) {
				m_PcmStream.SeekStream(0, SeekOrigin.Begin);
			} else {
				m_DisplayPosition -= size;
				m_PcmStream.SeekStream(m_DisplayPosition, SeekOrigin.Begin);
			}
			m_DisplaySource = m_PcmStream.Read(m_DisplayData.ReadSize);
			m_DisplayPosition = m_PcmStream.CurrentPos - m_DisplayData.ReadSize;
			showData(m_DisplaySource, m_DisplayPosition, m_PcmStream.StreamOffset, m_PcmStream.WaveFormat);
		}
		/// <summary>
		/// 後方移動（大）ボタンクリック時のイベントハンドラ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void toolStripButtonNextL_Click(object sender, EventArgs e)
		{
			int n = getMoveOrder();
			int size = (m_DisplayData.ReadSize / n) * n;

			// 終端にいれば何もしない
			if (m_DisplayPosition >= m_PcmStream.Length - m_DisplayData.ReadSize) {
				return;
			} else if (m_DisplayPosition >= m_PcmStream.Length - (size + m_DisplayData.ReadSize)) {
				m_DisplayPosition = m_PcmStream.Length - m_DisplayData.ReadSize;
				m_PcmStream.SeekStream(m_DisplayPosition, SeekOrigin.Begin);
			} else {
				m_DisplayPosition += size;
				m_PcmStream.SeekStream(m_DisplayPosition, SeekOrigin.Begin);
			}

			m_DisplaySource = m_PcmStream.Read(m_DisplayData.ReadSize);
			m_DisplayPosition = m_PcmStream.CurrentPos - m_DisplayData.ReadSize;
			showData(m_DisplaySource, m_DisplayPosition, m_PcmStream.StreamOffset, m_PcmStream.WaveFormat);
		}
		/// <summary>
		/// 後方移動ボタンクリック時のイベントハンドラ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void toolStripButtonNext_Click(object sender, EventArgs e)
		{
			int n = getMoveOrder();

			// 終端にいれば何もしない
			if (m_DisplayPosition >= m_PcmStream.Length - m_DisplayData.ReadSize) {
				return;
			}

			byte[] tmp = m_DisplaySource;
			m_PcmStream.SeekStream(m_DisplayPosition + m_DisplayData.ReadSize, SeekOrigin.Begin);
			byte[] next = m_PcmStream.Read(n);
			m_DisplaySource = new byte[tmp.Length];
			Array.Copy(tmp, n, m_DisplaySource, 0, tmp.Length - n);
			Array.Copy(next, 0, m_DisplaySource, m_DisplaySource.Length-n, n);
			m_DisplayPosition += n;
			showData(m_DisplaySource, m_DisplayPosition, m_PcmStream.StreamOffset, m_PcmStream.WaveFormat);
		}
		/// <summary>
		/// ファイルを開くボタンクリック時のイベントハンドラ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void toolStripButtonOpen_Click(object sender, EventArgs e)
		{
			OpenToolStripMenuItem_Click(sender, e);
		}

		private void toolStripCBDisp_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		#endregion

		#region 下請け雑メソッド

		/// <summary>
		/// 解析対象のファイルをオープンします。
		/// </summary>
		/// <param name="path">解析対象ファイルのパス</param>
		private void openPcm(string path)
		{
			try {
				m_PcmStream = new RiffReader(path);
			} catch {
				MessageBox.Show("ファイルのオープンに失敗しました。",
					"エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			bool b = m_PcmStream.Parse();
			if (!b) {
				MessageBox.Show("ファイルの解析に失敗しました。指定されたファイルは有効なWAVファイルではありません。",
					"エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			textBoxOffset.Text = m_PcmStream.CurrentPos.ToString();
			showHeader();
			setTitle(path);
			setToolbarOnOff(true);
			setMenuOnOff(true);
		}
		/// <summary>
		/// 解析対象のファイルを閉じます。
		/// </summary>
		private void closePcm()
		{
			m_PcmStream.Close();
			m_PcmStream = null;
			clearHeader();
			setTitle("");
			setToolbarOnOff(false);
			setMenuOnOff(false);
		}
		/// <summary>
		/// メイン表示領域の更新
		/// </summary>
		private void refreshMain()
		{
			if (m_DisplaySource != null && m_PcmStream != null) {
				showData(m_DisplaySource, m_DisplayPosition, m_PcmStream.StreamOffset, m_PcmStream.WaveFormat);
			}
		}
		/// <summary>
		/// 解析対象ファイルのWAVEFORMATEXヘッダーを表示します。
		/// </summary>
		private void showHeader()
		{
			// WaveFormatHeader
			int n = m_PcmStream.WaveFormat.FormatTag;
			string name = "";
			switch (n) {
				case WaveFormatTag.PCM:
					name = "PCM";
					break;
				case WaveFormatTag.IEEE_FLOAT:
					name = "PCM_FLOAT";
					break;
				case WaveFormatTag.ALAW:
					name = "ALAW";
					break;
				case WaveFormatTag.MULAW:
					name = "MULAW";
					break;
				case WaveFormatTag.EXTENSIBLE:
					name = "Extensible";
					break;
				default:
					name = "Unknown";
					break;
			}
			textBoxFormatTag.Text = name + "(" + n.ToString() + ")";
			textBoxChannels.Text = m_PcmStream.WaveFormat.Channels.ToString();
			textBoxFs.Text = m_PcmStream.WaveFormat.SamplesPerSecond.ToString();
			textBoxByteRate.Text = m_PcmStream.WaveFormat.AverageBytesPerSecond.ToString();
			textBoxBlockSize.Text = m_PcmStream.WaveFormat.BlockAlign.ToString();
			textBoxQbit.Text = m_PcmStream.WaveFormat.BitsPerSample.ToString();

			// WaveFormatExtensible
			if (m_PcmStream.WaveFormat.Extensible) {
				if (m_PcmStream.WaveFormat.BitsPerSample == 0) {
					labelSamples.Text = "ブロック毎のサンプル数";
				} else {
					labelSamples.Text = "サンプルの有効ビット数";
				}
				textBoxSamples.Text = m_PcmStream.WaveFormat.Samples.ToString();
				string s = String.Format(
					"{0:x2}{1:x2}{2:x2}{3:x2}-{4:x2}{5:x2}-{6:x2}{7:x2}-{8:x2}{9:x2}-{10:x2}{11:x2}{12:x2}{13:x2}{14:x2}{15:x2}",
					m_PcmStream.WaveFormat.SubFormat[0],
					m_PcmStream.WaveFormat.SubFormat[1],
					m_PcmStream.WaveFormat.SubFormat[2],
					m_PcmStream.WaveFormat.SubFormat[3],
					m_PcmStream.WaveFormat.SubFormat[4],
					m_PcmStream.WaveFormat.SubFormat[5],
					m_PcmStream.WaveFormat.SubFormat[6],
					m_PcmStream.WaveFormat.SubFormat[7],
					m_PcmStream.WaveFormat.SubFormat[8],
					m_PcmStream.WaveFormat.SubFormat[9],
					m_PcmStream.WaveFormat.SubFormat[10],
					m_PcmStream.WaveFormat.SubFormat[11],
					m_PcmStream.WaveFormat.SubFormat[12],
					m_PcmStream.WaveFormat.SubFormat[13],
					m_PcmStream.WaveFormat.SubFormat[14],
					m_PcmStream.WaveFormat.SubFormat[15]);
				textBoxGUID.Text = s;
				setChannelAssign(m_PcmStream.WaveFormat.ChannelMask);
			} else {
				labelSamples.Text = "サンプルの有効ビット数";
				textBoxSamples.Text = "-";
				textBoxGUID.Text = "-";
				clearChannelAssign();
			}
		}
		/// <summary>
		/// WAVEFORMATEXヘッダーの表示を消去します。
		/// </summary>
		private void clearHeader()
		{
			textBoxFormatTag.Text = "";
			textBoxChannels.Text = "";
			textBoxFs.Text = "";
			textBoxByteRate.Text = "";
			textBoxBlockSize.Text = "";
			textBoxQbit.Text = "";

			labelSamples.Text = "サンプルの有効ビット数";
			textBoxSamples.Text = "";
			textBoxGUID.Text = "";

			clearChannelAssign();
		}
		/// <summary>
		/// チャンネルアサインの表示設定を行います。
		/// </summary>
		/// <param name="assign"></param>
		private void setChannelAssign(uint assign)
		{
			if ((assign & WaveFormatChannelAssign.FRONT_LEFT) != 0) {
				cBFrontLeft.Enabled = cBFrontLeft.Checked = true;
			}
			if ((assign & WaveFormatChannelAssign.FRONT_RIGHT) != 0) {
				cBFrontRight.Enabled = cBFrontRight.Checked = true;
			}
			if ((assign & WaveFormatChannelAssign.FRONT_CENTER) != 0) {
				cBFrontCenter.Enabled = cBFrontCenter.Checked = true;
			}
			if ((assign & WaveFormatChannelAssign.LOW_FREQUENCY) != 0) {
				cBLowFreq.Enabled = cBLowFreq.Checked = true;
			}
			if ((assign & WaveFormatChannelAssign.BACK_LEFT) != 0) {
				cBBackLeft.Enabled = cBBackLeft.Checked = true;
			}
			if ((assign & WaveFormatChannelAssign.BACK_RIGHT) != 0) {
				cBBackRight.Enabled = cBBackRight.Checked = true;
			}
			if ((assign & WaveFormatChannelAssign.BACK_CENTER) != 0) {
				cBBackCenter.Enabled = cBBackCenter.Checked = true;
			}
			if ((assign & WaveFormatChannelAssign.SIDE_LEFT) != 0) {
				cBSideLeft.Enabled = cBSideLeft.Checked = true;
			}
			if ((assign & WaveFormatChannelAssign.SIDE_RIGHT) != 0) {
				cBSideRight.Enabled = cBSideRight.Checked = true;
			}
			if ((assign & WaveFormatChannelAssign.TOP_CENTER) != 0) {
				cBTopCenter.Enabled = cBTopCenter.Checked = true;
			}
			if ((assign & WaveFormatChannelAssign.FRONT_LEFT_OF_CENTER) != 0) {
				cBFrontLeftOfCenter.Enabled = cBFrontLeftOfCenter.Checked = true;
			}
			if ((assign & WaveFormatChannelAssign.FRONT_RIGHT_OF_CENTER) != 0) {
				cBFrontRightOfCenter.Enabled = cBFrontRightOfCenter.Checked = true;
			}
			if ((assign & WaveFormatChannelAssign.TOP_FRONT_LEFT) != 0) {
				cBTopFrontLeft.Enabled = cBTopFrontLeft.Checked = true;
			}
			if ((assign & WaveFormatChannelAssign.TOP_FRONT_RIGHT) != 0) {
				cBTopFrontRight.Enabled = cBTopFrontRight.Checked = true;
			}
			if ((assign & WaveFormatChannelAssign.TOP_FRONT_CENTER) != 0) {
				cBTopFrontCenter.Enabled = cBTopFrontCenter.Checked = true;
			}
			if ((assign & WaveFormatChannelAssign.TOP_BACK_LEFT) != 0) {
				cBTopBackLeft.Enabled = cBTopBackLeft.Checked = true;
			}
			if ((assign & WaveFormatChannelAssign.TOP_BACK_RIGHT) != 0) {
				cBTopBackRight.Enabled = cBTopBackRight.Checked = true;
			}
			if ((assign & WaveFormatChannelAssign.TOP_BACK_CENTER) != 0) {
				cBTopBackCenter.Enabled = cBTopBackCenter.Checked = true;
			}
			if ((assign & WaveFormatChannelAssign.RESERVED) != 0) {
				cBReserved.Enabled = cBReserved.Checked = true;
			}
		}
		/// <summary>
		/// チャンネルアサイン表示を消去します
		/// </summary>
		private void clearChannelAssign()
		{
			cBFrontLeft.Enabled = cBFrontRight.Enabled = false;
			cBFrontCenter.Enabled = cBLowFreq.Enabled = false;
			cBBackLeft.Enabled = cBBackRight.Enabled = cBBackCenter.Enabled = false;
			cBSideLeft.Enabled = cBSideRight.Enabled = false;
			cBTopCenter.Enabled = false;
			cBFrontLeftOfCenter.Enabled = cBFrontRightOfCenter.Enabled = false;
			cBTopFrontLeft.Enabled = cBTopFrontRight.Enabled = cBTopFrontCenter.Enabled = false;
			cBTopBackLeft.Enabled = cBTopBackRight.Enabled = cBTopBackCenter.Enabled = false;
			cBReserved.Enabled = false;

			cBFrontLeft.Checked = cBFrontRight.Checked = false;
			cBFrontCenter.Checked = cBLowFreq.Checked = false;
			cBBackLeft.Checked = cBBackRight.Checked = cBBackCenter.Checked = false;
			cBSideLeft.Checked = cBSideRight.Checked = false;
			cBTopCenter.Checked = false;
			cBFrontLeftOfCenter.Checked = cBFrontRightOfCenter.Checked = false;
			cBTopFrontLeft.Checked = cBTopFrontRight.Checked = cBTopFrontCenter.Checked = false;
			cBTopBackLeft.Checked = cBTopBackRight.Checked = cBTopBackCenter.Checked = false;
			cBReserved.Checked = false;
		}
		/// <summary>
		/// タイトルバーの表示を切り替えます。
		/// </summary>
		/// <param name="s">タイトルバーに表示するファイル名</param>
		private void setTitle(string s)
		{
			if (s == "") {
				this.Text = "WavAn";
			} else {
				this.Text = "WavAn - " + s;
			}
		}
		/// <summary>
		/// ツールバーの表示を切り替えます。
		/// </summary>
		/// <param name="opened">ファイルオープン時はtrue</param>
		private void setToolbarOnOff(bool opened)
		{
			if (opened) {
				toolStripButtonNext.Enabled = true;
				toolStripButtonNextL.Enabled = true;
				toolStripButtonPrev.Enabled = true;
				toolStripButtonPrevL.Enabled = true;
			} else {
				toolStripButtonNext.Enabled = false;
				toolStripButtonNextL.Enabled = false;
				toolStripButtonPrev.Enabled = false;
				toolStripButtonPrevL.Enabled = false;
			}
		}
		/// <summary>
		/// メニューの表示を切り替えます。
		/// </summary>
		/// <param name="opened">ファイルオープン時はtrue</param>
		private void setMenuOnOff(bool opened)
		{
			if (opened) {
				TopToolStripMenuItem.Enabled = true;
				TailToolStripMenuItem.Enabled = true;
			} else {
				TopToolStripMenuItem.Enabled = false;
				TailToolStripMenuItem.Enabled = false;
			}
		}
		/// <summary>
		/// 画面に表示するに表示データ列を設定します。
		/// </summary>
		/// <param name="b">表示するバイト列</param>
		/// <param name="offset">表示するストリームのバイトオフセット値（ストリーム先頭が0）</param>
		/// <param name="addrOffset">アドレスのオフセット</param>
		/// <param name="wf">ストリームフォーマット</param>
		private void showData(byte[] b, long offset, long addrOffset, WaveFormatEx wf)
		{
			// 表示アドレスを調整
			if (m_DisplayData.Setting.OffsetFrom == OffsetOrigin.StreamTop) {
				addrOffset = 0;
			}

			// メインデータの描画
			switch (m_DisplayData.Setting.StreamScale) {
				case DisplayStreamScale.Bit8:
					displayMainOrder8(b, offset, addrOffset, wf.BitsPerSample / 8, wf.Channels);
					break;
				case DisplayStreamScale.Bit16:
					displayMainOrder16(b, offset, addrOffset, wf.BitsPerSample / 8, wf.Channels);
					break;
				default:
					break;
			}

			// 詳細情報表示の描画
			textBoxOffset.Text = createHexStringWithDec(offset + addrOffset);
			if (m_PcmStream != null) {
				textBoxFrame.Text = (offset / m_PcmStream.WaveFormat.BlockAlign).ToString();
			}
		}
		/// <summary>
		/// メイン表示領域に8bit単位でデータを描画します。
		/// </summary>
		/// <param name="b">表示するバイト列</param>
		/// <param name="offset">表示するストリームのバイトオフセット値（ストリーム先頭が0）</param>
		/// <param name="addrOffset">アドレスのオフセット</param>
		/// <param name="qbit">量子化バイト数</param>
		/// <param name="ch">チャンネル数</param>
		private void displayMainOrder8(byte[] b, long offset, long addrOffset, int qsize, int ch)
		{
			// 1行58文字
			rTBMain.Text = "          +0 +1 +2 +3 +4 +5 +6 +7 +8 +9 +A +B +C +D +E +F " + Environment.NewLine;
			if (b != null) {
				for (int i = 0; i < b.Length; i += 16) {
					StringBuilder sb = new StringBuilder(64);

					long offh = (offset + addrOffset + i) / 0x10000;
					long offl = (offset + addrOffset + i) % 0x10000;
					string addr = String.Format("{0:X4}", offh) + ":" + String.Format("{0:X4}", offl) + " ";
					sb.Append(addr);

					for (int j = 0; j < 16; j++) {
						sb.Append(b[i + j].ToString("X2"));
						sb.Append(" ");
					}

					sb.Append(Environment.NewLine);
					rTBMain.Text += sb.ToString();
				}
				rTBMain.Text = rTBMain.Text.Substring(0, rTBMain.Text.Length - 1);
			}

			// 色設定

			// 全体は白
			rTBMain.Select(0, rTBMain.Text.Length);
			rTBMain.SelectionBackColor = Color.White;
			// 最初の行
			rTBMain.Select(0, 57);
			rTBMain.SelectionBackColor = Color.LightGray;
			// データの行
			if (b != null) {
				for (int i = 0; i < b.Length / 16; i++) {
					rTBMain.Select(59 * (i + 1), 9);
					rTBMain.SelectionBackColor = Color.LightGray;
				}
				if (m_DisplayData.Setting.ChannelColor) {
					displayColorOrder8(b.Length, offset, qsize, ch);
				}
			}
		}
		/// <summary>
		/// データ列の8bit表示時の色分け表示
		/// </summary>
		/// <param name="length">表示するバイト列長</param>
		/// <param name="offset">オーディオフレーム先頭からのバイト数</param>
		/// <param name="qsize">量子化バイト数</param>
		/// <param name="ch">チャンネル数</param>
		private void displayColorOrder8(int length, long offset, int qsize, int ch)
		{
			int block = ch * qsize;
			int start = (int)(offset % block);
			switch (ch) {
				default:
				case 1:
					// 淡色表示
					break;
				case 2:
					if (qsize == 1) {
						for (int i = 0; i < length; i++) {
							int offs = (i % block) + start;
							if (1 <= offs && offs < 2 || 3 <= offs && offs < 4) {
								setTextBgColorOrder8(i, Color.Yellow);
							}
						}
					} else if (qsize == 2) {
						for (int i = 0; i < length; i++) {
							int offs = (i % block) + start;
							if (2 <= offs && offs < 4 || 6 <= offs && offs < 8) {
								setTextBgColorOrder8(i, Color.Yellow);
							}
						}
					} else if (qsize == 3) {
						for (int i = 0; i < length; i++) {
							int offs = (i % block) + start;
							if (3 <= offs && offs < 6 || 9 <= offs && offs < 12) {
								setTextBgColorOrder8(i, Color.Yellow);
							}
						}
					} else if (qsize == 4) {
						for (int i = 0; i < length; i++) {
							int offs = (i % block) + start;
							if (4 <= offs && offs < 8 || 12 <= offs && offs < 16) {
								setTextBgColorOrder8(i, Color.Yellow);
							}
						}
					}
					break;
				case 3:
					if (qsize == 1) {
						for (int i = 0; i < length; i++) {
							int offs = (i % block) + start;
							if (offs == 1 || offs == 4) {
								setTextBgColorOrder8(i, Color.LightGreen);
							} else if (offs == 2) {
								setTextBgColorOrder8(i, Color.Yellow);
							}
						}
					} else if (qsize == 2) {
						for (int i = 0; i < length; i++) {
							int offs = (i % block) + start;
							if (2 <= offs && offs < 4 || 8 <= offs && offs < 10) {
								setTextBgColorOrder8(i, Color.LightGreen);
							} else if (4 <= offs && offs < 6 || 10 <= offs && offs < 12) {
								setTextBgColorOrder8(i, Color.Yellow);
							}
						}
					} else if (qsize == 3) {
						// 未テスト
						for (int i = 0; i < length; i++) {
							int offs = (i % block) + start;
							if (3 <= offs && offs < 6 || 12 <= offs && offs < 15) {
								setTextBgColorOrder8(i, Color.LightGreen);
							} else if (6 <= offs && offs < 9 || 15 <= offs && offs < 18) {
								setTextBgColorOrder8(i, Color.Yellow);
							}
						}
					} else if (qsize == 4) {
						// 未テスト
						for (int i = 0; i < length; i++) {
							int offs = (i % block) + start;
							if (4 <= offs && offs < 8 || 16 <= offs && offs < 20) {
								setTextBgColorOrder8(i, Color.LightGreen);
							} else if (8 <= offs && offs < 12 || 20 <= offs && offs < 24) {
								setTextBgColorOrder8(i, Color.Yellow);
							}
						}
					}
					break;
				case 4:
					if (qsize == 1) {
						for (int i = 0; i < length; i++) {
							int offs = (i % block) + start;
							if (offs == 1 || offs == 5) {
								setTextBgColorOrder8(i, Color.LightSkyBlue);
							} else if (offs == 2 || offs == 6) {
								setTextBgColorOrder8(i, Color.LightGreen);
							} else if (offs == 3 || offs == 7) {
								setTextBgColorOrder8(i, Color.Yellow);
							}
						}
					} else if (qsize == 2) {
						for (int i = 0; i < length; i++) {
							int offs = (i % block) + start;
							if (2 <= offs && offs < 4 || 10 <= offs && offs < 12) {
								setTextBgColorOrder8(i, Color.LightSkyBlue);
							} else if (4 <= offs && offs < 6 || 12 <= offs && offs < 14) {
								setTextBgColorOrder8(i, Color.LightGreen);
							} else if (6 <= offs && offs < 8 || 14 <= offs && offs < 16) {
								setTextBgColorOrder8(i, Color.Yellow);
							}
						}
					} else if (qsize == 3) {
						for (int i = 0; i < length; i++) {
							int offs = (i % block) + start;
							if (3 <= offs && offs < 6 || 15 <= offs && offs < 18) {
								setTextBgColorOrder8(i, Color.LightSkyBlue);
							} else if (6 <= offs && offs < 9 || 18 <= offs && offs < 21) {
								setTextBgColorOrder8(i, Color.LightGreen);
							} else if (9 <= offs && offs < 12 || 21 <= offs && offs < 24) {
								setTextBgColorOrder8(i, Color.Yellow);
							}
						}
					} else if (qsize == 4) {
						for (int i = 0; i < length; i++) {
							int offs = (i % block) + start;
							if (4 <= offs && offs < 8 || 20 <= offs && offs < 24) {
								setTextBgColorOrder8(i, Color.LightSkyBlue);
							} else if (8 <= offs && offs < 12 || 24 <= offs && offs < 28) {
								setTextBgColorOrder8(i, Color.LightGreen);
							} else if (12 <= offs && offs < 16 || 28 <= offs && offs < 32) {
								setTextBgColorOrder8(i, Color.Yellow);
							}
						}
					}
					break;
				case 5:
					// 未確認
					break;
				case 6:
					if (qsize == 1) {
						for (int i = 0; i < length; i++) {
							int offs = (i % block) + start;
							if (offs == 1 || offs == 7) {
								setTextBgColorOrder8(i, Color.LawnGreen);
							} else if (offs == 2 || offs == 8) {
								setTextBgColorOrder8(i, Color.LightPink);
							} else if (offs == 3 || offs == 9) {
								setTextBgColorOrder8(i, Color.LightSkyBlue);
							} else if (offs == 4 || offs == 10) {
								setTextBgColorOrder8(i, Color.LightGreen);
							} else if (offs == 5 || offs == 11) {
								setTextBgColorOrder8(i, Color.Yellow);
							}
						}
					} else if (qsize == 2) {
						for (int i = 0; i < length; i++) {
							int offs = (i % block) + start;
							if (2 <= offs && offs < 4 || 14 <= offs && offs < 16) {
								setTextBgColorOrder8(i, Color.LawnGreen);
							} else if (4 <= offs && offs < 6 || 16 <= offs && offs < 18) {
								setTextBgColorOrder8(i, Color.LightPink);
							} else if (6 <= offs && offs < 8 || 18 <= offs && offs < 20) {
								setTextBgColorOrder8(i, Color.LightSkyBlue);
							} else if (8 <= offs && offs < 10 || 20 <= offs && offs < 22) {
								setTextBgColorOrder8(i, Color.LightGreen);
							} else if (10 <= offs && offs < 12 || 22 <= offs && offs < 24) {
								setTextBgColorOrder8(i, Color.Yellow);
							}
						}
					} else if (qsize == 3) {
						for (int i = 0; i < length; i++) {
							int offs = (i % block) + start;
							if (3 <= offs && offs < 6 || 21 <= offs && offs < 24) {
								setTextBgColorOrder8(i, Color.LawnGreen);
							} else if (6 <= offs && offs < 9 || 24 <= offs && offs < 27) {
								setTextBgColorOrder8(i, Color.LightPink);
							} else if (9 <= offs && offs < 12 || 27 <= offs && offs < 30) {
								setTextBgColorOrder8(i, Color.LightSkyBlue);
							} else if (12 <= offs && offs < 15 || 30 <= offs && offs < 33) {
								setTextBgColorOrder8(i, Color.LightGreen);
							} else if (15 <= offs && offs < 18 || 33 <= offs && offs < 36) {
								setTextBgColorOrder8(i, Color.Yellow);
							}
						}
					} else if (qsize == 4) {
						for (int i = 0; i < length; i++) {
							int offs = (i % block) + start;
							if (4 <= offs && offs < 8 || 28 <= offs && offs < 32) {
								setTextBgColorOrder8(i, Color.LawnGreen);
							} else if (8 <= offs && offs < 12 || 32 <= offs && offs < 36) {
								setTextBgColorOrder8(i, Color.LightPink);
							} else if (12 <= offs && offs < 16 || 36 <= offs && offs < 40) {
								setTextBgColorOrder8(i, Color.LightSkyBlue);
							} else if (16 <= offs && offs < 20 || 40 <= offs && offs < 44) {
								setTextBgColorOrder8(i, Color.LightGreen);
							} else if (20 <= offs && offs < 24 || 44 <= offs && offs < 48) {
								setTextBgColorOrder8(i, Color.Yellow);
							}
						}
					}
					break;
				case 7:
					if (qsize == 1) {
						for (int i = 0; i < length; i++) {
							int offs = (i % block) + start;
							if (offs == 1 || offs == 8) {
								setTextBgColorOrder8(i, Color.MediumPurple);
							} else if (offs == 2 || offs == 9) {
								setTextBgColorOrder8(i, Color.LawnGreen);
							} else if (offs == 3 || offs == 10) {
								setTextBgColorOrder8(i, Color.LightPink);
							} else if (offs == 4 || offs == 11) {
								setTextBgColorOrder8(i, Color.LightSkyBlue);
							} else if (offs == 5 || offs == 12) {
								setTextBgColorOrder8(i, Color.LightGreen);
							} else if (offs == 6 || offs == 13) {
								setTextBgColorOrder8(i, Color.Yellow);
							}
						}
					} else if (qsize == 2) {
						for (int i = 0; i < length; i++) {
							int offs = (i % block) + start;
							if (2 <= offs && offs < 4 || 16 <= offs && offs < 18) {
								setTextBgColorOrder8(i, Color.MediumPurple);
							} else if (4 <= offs && offs < 6 || 18 <= offs && offs < 20) {
								setTextBgColorOrder8(i, Color.LawnGreen);
							} else if (6 <= offs && offs < 8 || 20 <= offs && offs < 22) {
								setTextBgColorOrder8(i, Color.LightPink);
							} else if (8 <= offs && offs < 10 || 22 <= offs && offs < 24) {
								setTextBgColorOrder8(i, Color.LightSkyBlue);
							} else if (10 <= offs && offs < 12 || 24 <= offs && offs < 26) {
								setTextBgColorOrder8(i, Color.LightGreen);
							} else if (12 <= offs && offs < 14 || 26 <= offs && offs < 28) {
								setTextBgColorOrder8(i, Color.Yellow);
							}
						}
					} else if (qsize == 3) {
						for (int i = 0; i < length; i++) {
							int offs = (i % block) + start;
							if (3 <= offs && offs < 6 || 24 <= offs && offs < 27) {
								setTextBgColorOrder8(i, Color.MediumPurple);
							} else if (6 <= offs && offs < 9 || 27 <= offs && offs < 30) {
								setTextBgColorOrder8(i, Color.LawnGreen);
							} else if (9 <= offs && offs < 12 || 30 <= offs && offs < 33) {
								setTextBgColorOrder8(i, Color.LightPink);
							} else if (12 <= offs && offs < 15 || 33 <= offs && offs < 36) {
								setTextBgColorOrder8(i, Color.LightSkyBlue);
							} else if (15 <= offs && offs < 18 || 36 <= offs && offs < 39) {
								setTextBgColorOrder8(i, Color.LightGreen);
							} else if (18 <= offs && offs < 21 || 39 <= offs && offs < 42) {
								setTextBgColorOrder8(i, Color.Yellow);
							}
						}
					} else if (qsize == 4) {
						for (int i = 0; i < length; i++) {
							int offs = (i % block) + start;
							if (4 <= offs && offs < 8 || 32 <= offs && offs < 36) {
								setTextBgColorOrder8(i, Color.MediumPurple);
							} else if (8 <= offs && offs < 12 || 36 <= offs && offs < 40) {
								setTextBgColorOrder8(i, Color.LawnGreen);
							} else if (12 <= offs && offs < 16 || 40 <= offs && offs < 44) {
								setTextBgColorOrder8(i, Color.LightPink);
							} else if (16 <= offs && offs < 20 || 44 <= offs && offs < 48) {
								setTextBgColorOrder8(i, Color.LightSkyBlue);
							} else if (20 <= offs && offs < 24 || 48 <= offs && offs < 52) {
								setTextBgColorOrder8(i, Color.LightGreen);
							} else if (24 <= offs && offs < 28 || 52 <= offs && offs < 56) {
								setTextBgColorOrder8(i, Color.Yellow);
							}
						}
					}
					break;
				case 8:
					if (qsize == 1) {
						for (int i = 0; i < length; i++) {
							int offs = (i % block) + start;
							if (offs == 1 || offs == 9) {
								setTextBgColorOrder8(i, Color.Crimson);
							} else if (offs == 2 || offs == 10) {
								setTextBgColorOrder8(i, Color.MediumPurple);
							} else if (offs == 3 || offs == 11) {
								setTextBgColorOrder8(i, Color.LawnGreen);
							} else if (offs == 4 || offs == 12) {
								setTextBgColorOrder8(i, Color.LightPink);
							} else if (offs == 5 || offs == 13) {
								setTextBgColorOrder8(i, Color.LightSkyBlue);
							} else if (offs == 6 || offs == 14) {
								setTextBgColorOrder8(i, Color.LightGreen);
							} else if (offs == 7 || offs == 15) {
								setTextBgColorOrder8(i, Color.Yellow);
							}
						}
					} else if (qsize == 2) {
						for (int i = 0; i < length; i++) {
							int offs = (i % block) + start;
							if (2 <= offs && offs < 4 || 18 <= offs && offs < 20) {
								setTextBgColorOrder8(i, Color.Crimson);
							} else if (4 <= offs && offs < 6 || 20 <= offs && offs < 22) {
								setTextBgColorOrder8(i, Color.MediumPurple);
							} else if (6 <= offs && offs < 8 || 22 <= offs && offs < 24) {
								setTextBgColorOrder8(i, Color.LawnGreen);
							} else if (8 <= offs && offs < 10 || 24 <= offs && offs < 26) {
								setTextBgColorOrder8(i, Color.LightPink);
							} else if (10 <= offs && offs < 12 || 26 <= offs && offs < 28) {
								setTextBgColorOrder8(i, Color.LightSkyBlue);
							} else if (12 <= offs && offs < 14 || 28 <= offs && offs < 30) {
								setTextBgColorOrder8(i, Color.LightGreen);
							} else if (14 <= offs && offs < 16 || 30 <= offs && offs < 32) {
								setTextBgColorOrder8(i, Color.Yellow);
							}
						}
					} else if (qsize == 3) {
						for (int i = 0; i < length; i++) {
							int offs = (i % block) + start;
							if (3 <= offs && offs < 6 || 27 <= offs && offs < 30) {
								setTextBgColorOrder8(i, Color.Crimson);
							} else if (6 <= offs && offs < 9 || 30 <= offs && offs < 33) {
								setTextBgColorOrder8(i, Color.MediumPurple);
							} else if (9 <= offs && offs < 12 || 33 <= offs && offs < 36) {
								setTextBgColorOrder8(i, Color.LawnGreen);
							} else if (12 <= offs && offs < 15 || 36 <= offs && offs < 39) {
								setTextBgColorOrder8(i, Color.LightPink);
							} else if (15 <= offs && offs < 18 || 39 <= offs && offs < 42) {
								setTextBgColorOrder8(i, Color.LightSkyBlue);
							} else if (18 <= offs && offs < 21 || 42 <= offs && offs < 45) {
								setTextBgColorOrder8(i, Color.LightGreen);
							} else if (21 <= offs && offs < 24 || 45 <= offs && offs < 48) {
								setTextBgColorOrder8(i, Color.Yellow);
							}
						}
					} else if (qsize == 4) {
						for (int i = 0; i < length; i++) {
							int offs = (i % block) + start;
							if (4 <= offs && offs < 8 || 36 <= offs && offs < 40) {
								setTextBgColorOrder8(i, Color.Crimson);
							} else if (8 <= offs && offs < 12 || 40 <= offs && offs < 44) {
								setTextBgColorOrder8(i, Color.MediumPurple);
							} else if (12 <= offs && offs < 16 || 44 <= offs && offs < 48) {
								setTextBgColorOrder8(i, Color.LawnGreen);
							} else if (16 <= offs && offs < 20 || 48 <= offs && offs < 52) {
								setTextBgColorOrder8(i, Color.LightPink);
							} else if (20 <= offs && offs < 24 || 52 <= offs && offs < 56) {
								setTextBgColorOrder8(i, Color.LightSkyBlue);
							} else if (24 <= offs && offs < 28 || 56 <= offs && offs < 60) {
								setTextBgColorOrder8(i, Color.LightGreen);
							} else if (28 <= offs && offs < 32 || 60 <= offs && offs < 64) {
								setTextBgColorOrder8(i, Color.Yellow);
							}
						}
					}
					break;
				case 9:
					if (qsize == 1) {
						for (int i = 0; i < length; i++) {
							int offs = (i % block) + start;
							if (offs == 1 || offs == 10) {
								setTextBgColorOrder8(i, Color.DarkGray);
							} else if (offs == 2 || offs == 11) {
								setTextBgColorOrder8(i, Color.Crimson);
							} else if (offs == 3 || offs == 12) {
								setTextBgColorOrder8(i, Color.MediumPurple);
							} else if (offs == 4 || offs == 13) {
								setTextBgColorOrder8(i, Color.LawnGreen);
							} else if (offs == 5 || offs == 14) {
								setTextBgColorOrder8(i, Color.LightPink);
							} else if (offs == 6 || offs == 15) {
								setTextBgColorOrder8(i, Color.LightSkyBlue);
							} else if (offs == 7 || offs == 16) {
								setTextBgColorOrder8(i, Color.LightGreen);
							} else if (offs == 8 || offs == 17) {
								setTextBgColorOrder8(i, Color.Yellow);
							}
						}
					} else if (qsize == 2) {
						for (int i = 0; i < length; i++) {
							int offs = (i % block) + start;
							if (2 <= offs && offs < 4 || 20 <= offs && offs < 22) {
								setTextBgColorOrder8(i, Color.DarkGray);
							} else if (4 <= offs && offs < 6 || 22 <= offs && offs < 24) {
								setTextBgColorOrder8(i, Color.Crimson);
							} else if (6 <= offs && offs < 8 || 24 <= offs && offs < 26) {
								setTextBgColorOrder8(i, Color.MediumPurple);
							} else if (8 <= offs && offs < 10 || 26 <= offs && offs < 28) {
								setTextBgColorOrder8(i, Color.LawnGreen);
							} else if (10 <= offs && offs < 12 || 28 <= offs && offs < 30) {
								setTextBgColorOrder8(i, Color.LightPink);
							} else if (12 <= offs && offs < 14 || 30 <= offs && offs < 32) {
								setTextBgColorOrder8(i, Color.LightSkyBlue);
							} else if (14 <= offs && offs < 16 || 32 <= offs && offs < 34) {
								setTextBgColorOrder8(i, Color.LightGreen);
							} else if (16 <= offs && offs < 18 || 34 <= offs && offs < 36) {
								setTextBgColorOrder8(i, Color.Yellow);
							}
						}
					} else if (qsize == 3) {
						for (int i = 0; i < length; i++) {
							int offs = (i % block) + start;
							if (3 <= offs && offs < 6 || 30 <= offs && offs < 33) {
								setTextBgColorOrder8(i, Color.DarkGray);
							} else if (6 <= offs && offs < 9 || 33 <= offs && offs < 36) {
								setTextBgColorOrder8(i, Color.Crimson);
							} else if (9 <= offs && offs < 12 || 36 <= offs && offs < 39) {
								setTextBgColorOrder8(i, Color.MediumPurple);
							} else if (12 <= offs && offs < 15 || 39 <= offs && offs < 42) {
								setTextBgColorOrder8(i, Color.LawnGreen);
							} else if (15 <= offs && offs < 18 || 42 <= offs && offs < 45) {
								setTextBgColorOrder8(i, Color.LightPink);
							} else if (18 <= offs && offs < 21 || 45 <= offs && offs < 48) {
								setTextBgColorOrder8(i, Color.LightSkyBlue);
							} else if (21 <= offs && offs < 24 || 48 <= offs && offs < 51) {
								setTextBgColorOrder8(i, Color.LightGreen);
							} else if (24 <= offs && offs < 27 || 51 <= offs && offs < 54) {
								setTextBgColorOrder8(i, Color.Yellow);
							}
						}
					} else if (qsize == 4) {
						for (int i = 0; i < length; i++) {
							int offs = (i % block) + start;
							if (4 <= offs && offs < 8 || 40 <= offs && offs < 44) {
								setTextBgColorOrder8(i, Color.DarkGray);
							} else if (8 <= offs && offs < 12 || 44 <= offs && offs < 48) {
								setTextBgColorOrder8(i, Color.Crimson);
							} else if (12 <= offs && offs < 16 || 48 <= offs && offs < 52) {
								setTextBgColorOrder8(i, Color.MediumPurple);
							} else if (16 <= offs && offs < 20 || 52 <= offs && offs < 56) {
								setTextBgColorOrder8(i, Color.LawnGreen);
							} else if (20 <= offs && offs < 24 || 56 <= offs && offs < 60) {
								setTextBgColorOrder8(i, Color.LightPink);
							} else if (24 <= offs && offs < 28 || 60 <= offs && offs < 64) {
								setTextBgColorOrder8(i, Color.LightSkyBlue);
							} else if (28 <= offs && offs < 32 || 64 <= offs && offs < 68) {
								setTextBgColorOrder8(i, Color.LightGreen);
							} else if (32 <= offs && offs < 36 || 68 <= offs && offs < 72) {
								setTextBgColorOrder8(i, Color.Yellow);
							}
						}
					}
					break;
			}
		}
		/// <summary>
		/// データの位置を表示上の位置に変換する（8bit表示時用）
		/// </summary>
		/// <param name="pos">バイト列内の位置</param>
		/// <returns>表示位置</returns>
		private int toTextOffsetOrder8(int pos)
		{
			int line = pos / 16;
			int offs = pos % 16;

			return (59 * (line + 1) + 9 + 1 + offs * 3);
		}
		/// <summary>
		/// 一文字分のデータの背景色を設定します
		/// </summary>
		/// <param name="pos">表示する文字の位置</param>
		/// <param name="c">背景色</param>
		private void setTextBgColorOrder8(int pos, System.Drawing.Color c)
		{
			int n = toTextOffsetOrder8(pos);
			rTBMain.Select(n, 3);
			rTBMain.SelectionBackColor = c;
		}
		/// <summary>
		/// メイン表示領域に16bit単位でデータを描画します。
		/// </summary>
		/// <param name="b">表示するバイト列</param>
		/// <param name="offset">表示するストリームのバイトオフセット値（ストリーム先頭が0）</param>
		/// <param name="addrOffset">アドレスのオフセット</param>
		/// <param name="qbit">量子化バイト数</param>
		/// <param name="ch">チャンネル数</param>
		private void displayMainOrder16(byte[] b, long offset, long addrOffset, int qsize, int ch)
		{
			// 1行58文字
			// rTBMain.Text = "          +0 +1 +2 +3 +4 +5 +6 +7 +8 +9 +A +B +C +D +E +F " + Environment.NewLine;
			// 1行50文字
			rTBMain.Text = "           +0   +2   +4   +6   +8   +A   +C   +E  " + Environment.NewLine;
			if (b != null) {
				for (int i = 0; i < b.Length; i += 16) {
					StringBuilder sb = new StringBuilder(64);

					long offh = (offset + addrOffset + i) / 0x10000;
					long offl = (offset + addrOffset + i) % 0x10000;
					string addr = String.Format("{0:X4}", offh) + ":" + String.Format("{0:X4}", offl) + " ";
					sb.Append(addr);

					for (int j = 0; j < 16; j+=2) {
						sb.Append(b[i + j].ToString("X2") + b[i + j + 1].ToString("X2"));
						sb.Append(" ");
					}

					sb.Append(Environment.NewLine);
					rTBMain.Text += sb.ToString();
				}
				rTBMain.Text = rTBMain.Text.Substring(0, rTBMain.Text.Length - 1);
			}

			// 色設定

			// 全体は白
			rTBMain.Select(0, rTBMain.Text.Length);
			rTBMain.SelectionBackColor = Color.White;
			// 最初の行
			rTBMain.Select(0, 49);
			rTBMain.SelectionBackColor = Color.LightGray;
			// データの行
			if (b != null) {
				for (int i = 0; i < b.Length / 16; i++) {
					rTBMain.Select(51 * (i + 1), 9);
					rTBMain.SelectionBackColor = Color.LightGray;
				}
				if (m_DisplayData.Setting.ChannelColor) {
					
				}
			}
		}
		/// <summary>
		/// 現在のフォームサイズから表示可能な行数を計算します。
		/// </summary>
		private void calcMainRtbMaxLine()
		{
			// 2行分の座標を得るため、仮文字列を追加
			rTBMain.Text = "1" + Environment.NewLine + "2";
			// 1行高さ＝2行目Y座標-1行目Y座標
			int lineHeight =
			  rTBMain.GetPositionFromCharIndex(rTBMain.GetFirstCharIndexFromLine(1)).Y
			  - rTBMain.GetPositionFromCharIndex(rTBMain.GetFirstCharIndexFromLine(0)).Y;
			// 仮文字列を削除
			rTBMain.Clear();
			// 最大行数＝クライアント領域の高さ÷1行高さ
			m_DisplayData.MaxLine = rTBMain.ClientSize.Height / lineHeight;
			m_DisplayData.MaxLine--;
		}
		/// <summary>
		/// 16進表記＋10進表記の文字列を生成して返します。
		/// </summary>
		/// <param name="n">表示する値</param>
		/// <returns>生成した文字列</returns>
		private string createHexStringWithDec(long n)
		{
			return "0x" + n.ToString("x") + " (" + n.ToString() + ")";
		}

		private int getMoveOrder()
		{
			int order = 1;

			if (m_PcmStream == null) {
				return order;
			}

			if (m_DisplayData.Setting.MovingMode == MovingScale.Frame) {
				order = m_PcmStream.WaveFormat.BlockAlign;
			} else {
				if (m_PcmStream.WaveFormat.BitsPerSample == 8) {
					order = 1;
				} else {
					order = 1;
				}
			}
			return order;
		}

		#endregion

	}
}
