using System;
using System.IO;
using System.Text;

namespace WavAn
{
	public struct WaveFormatEx
	{
		public short FormatTag;
		public short Channels;
		public int SamplesPerSecond;
		public int AverageBytesPerSecond;
		public short BlockAlign;
		public short BitsPerSample;
		/// <summary>WAVEFORMATEXTENSIBLEの有無</summary>
		public bool Extensible;
		/// <summary>WAVEFORMATEXTENSIBLEのSamples union</summary>
		public short Samples;
		/// <summary>WAVEFORMATEXTENSIBLEのチャンネルアサイン</summary>
		public uint ChannelMask;
		/// <summary>WAVEFORMATEXTENSIBLEのGUID</summary>
		public byte[] SubFormat;
	}

	/// <summary>
	/// WaveFormatTagに入りうるPCMの設定値
	/// </summary>
	public static class WaveFormatTag
	{
		public const int PCM = 1;
		public const int IEEE_FLOAT = 3;
		public const int ALAW = 6;
		public const int MULAW = 7;
		public const int EXTENSIBLE = -2;
	}
	public static class WaveFormatChannelAssign
	{
		public const uint FRONT_LEFT = 0x1;
		public const uint FRONT_RIGHT = 0x2;
		public const uint FRONT_CENTER = 0x4;
		public const uint LOW_FREQUENCY = 0x8;
		public const uint BACK_LEFT = 0x10;
		public const uint BACK_RIGHT = 0x20;
		public const uint FRONT_LEFT_OF_CENTER = 0x40;
		public const uint FRONT_RIGHT_OF_CENTER = 0x80;
		public const uint BACK_CENTER = 0x100;
		public const uint SIDE_LEFT = 0x200;
		public const uint SIDE_RIGHT = 0x400;
		public const uint TOP_CENTER = 0x800;
		public const uint TOP_FRONT_LEFT = 0x1000;
		public const uint TOP_FRONT_CENTER = 0x2000;
		public const uint TOP_FRONT_RIGHT = 0x4000;
		public const uint TOP_BACK_LEFT = 0x8000;
		public const uint TOP_BACK_CENTER = 0x10000;
		public const uint TOP_BACK_RIGHT = 0x20000;
		public const uint RESERVED = 0x80000000;
	}

	public interface IPcmStream
	{
		/// <summary>ファイルのパス</summary>
		string FilePath { get; }
		/// <summary>ヘッダー情報</summary>
		WaveFormatEx WaveFormat { get; }
		/// <summary>ストリームの長さ</summary>
		long Length { get; }
		/// <summary>ストリームの読み出し位置</summary>
		long CurrentPos { get; }
		/// <summary>ストリームの開始バイトオフセット</summary>
		long StreamOffset { get; }

		bool Parse();
		byte[] Read(int n);
		long SeekStream(long n, SeekOrigin origin);
		void Close();
	}
}
