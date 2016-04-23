using System;

namespace WavAn
{
	/// <summary>
	/// 移動単位
	/// </summary>
	public enum MovingScale
	{
		/// <summary>バイト単位</summary>
		Byte,
		/// <summary>フレーム単位</summary>
		Frame
	}
	/// <summary>
	/// 表示オフセットの起点
	/// </summary>
	public enum OffsetOrigin
	{
		/// <summary>ファイル先頭</summary>
		FileTop,
		/// <summary>ストリーム先頭</summary>
		StreamTop
	}
	/// <summary>
	/// ストリーム表示モード
	/// </summary>
	public enum DisplayStreamScale
	{
		Bit8,
		Bit16,
		Bit24,
		Bit32
	}
	/// <summary>
	/// 表示設定
	/// </summary>
	public class DisplaySetting : ICloneable
	{
		/// <summary>チャンネル毎カラー設定</summary>
		private bool channelColor;
		/// <summary>ストリームに合わせて表示モードを自動選択</summary>
		private bool usingStreamQbit;
		/// <summary>移動方式</summary>
		private MovingScale movingMode;
		/// <summary>表示起点</summary>
		private OffsetOrigin offsetFrom;
		/// <summary>ストリーム表示モード</summary>
		private DisplayStreamScale streamScale;

		/// <summary>チャンネル毎カラー設定</summary>
		public bool ChannelColor
		{
			get { return channelColor; }
			set { channelColor = value; }
		}
		/// <summary>ストリームに合わせて表示モードを自動選択</summary>
		public bool UsingStreamQbit
		{
			get { return usingStreamQbit; }
			set { usingStreamQbit = value; }
		}
		/// <summary>移動方式</summary>
		public MovingScale MovingMode
		{
			get { return movingMode; }
			set { movingMode = value; }
		}
		/// <summary>表示起点</summary>
		public OffsetOrigin OffsetFrom
		{
			get { return offsetFrom; }
			set { offsetFrom = value; }
		}
		/// <summary>ストリーム表示モード</summary>
		public DisplayStreamScale StreamScale
		{
			get { return streamScale; }
			set { streamScale = value; }
		}

		public DisplaySetting()
		{
			channelColor = true;
			usingStreamQbit = false;
			movingMode = MovingScale.Frame;
			offsetFrom = OffsetOrigin.StreamTop;
			streamScale = DisplayStreamScale.Bit8;
		}

		public object Clone()
		{
			return this.MemberwiseClone();
		}
	}

	class DisplayData
	{
		/// <summary>表示設定</summary>
		private DisplaySetting setting;
		/// <summary>最大表示可能行数</summary>
		private int maxLine;
		/// <summary>画面に合わせた表示で読み取りが必要なバイトサイズ</summary>
		private int readSize;

		/// <summary>表示設定</summary>
		public DisplaySetting Setting
		{
			get { return setting; }
			set { setting = value; }
		}
		/// <summary>最大表示可能行数</summary>
		public int MaxLine
		{
			get { return maxLine; }
			set { maxLine = value; }
		}
		/// <summary>画面に合わせた表示で読み取りが必要なバイトサイズ</summary>
		public int ReadSize
		{
			get { return readSize; }
			set { readSize = value; }
		}

		public DisplayData()
		{
			setting = new DisplaySetting();
			maxLine = 0;
		}
	}
}
