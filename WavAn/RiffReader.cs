using System;
using System.IO;
using System.Text;

namespace WavAn
{
	public class RiffReader : IPcmStream, IDisposable
    {
        /// <summary>解析対したWaveFormatヘッダー</summary>
        private WaveFormatEx waveFormat;
        /// <summary>ファイルのストリーム開始バイトオフセット</summary>
        private long streamOffset;
        /// <summary>ファイルのストリームバイトサイズ</summary>
        private long streamLength;
        /// <summary>ストリーム読み込み用のファイルストリーム</summary>
        private FileStream streamFs;
        /// <summary>ストリーム読み込み用のBinaryReader</summary>
        private BinaryReader streamBr;

		/// <summary>解析対象ファイルパス</summary>
		public string FilePath
		{
			get { return streamFs.Name; }
		}
		/// <summary>解析したWaveFormatヘッダー</summary>
		public WaveFormatEx WaveFormat
		{
			get { return waveFormat; }
		}
		/// <summary>ストリームの有効バイトサイズ</summary>
		public long Length
		{
			get { return streamLength; }
		}
		/// <summary>ストリームの現在の読み込みバイトオフセット</summary>
		public long CurrentPos
		{
			get { return (streamFs.Position - streamOffset); }
		}
		public long StreamOffset
		{
			get { return streamOffset; }
		}

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="path">ファイルのパス</param>
        public RiffReader(string path)
        {
            waveFormat = new WaveFormatEx();
            streamOffset = streamLength = 0;

			if (!File.Exists(path)) {
                throw new IOException("no file");
            }

            try {
				streamFs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
				streamBr = new BinaryReader(streamFs);
            } catch (Exception) {   // 乱暴だがこれで問題になる状況はよほどの状況
				Close();
				throw;
            }

			InitializeDisposeFinalizePattern();
        }

		/// <summary>
		/// ファイルの解析を行います。
		/// </summary>
		/// <returns>解析に成功すれば真</returns>
		public bool Parse()
		{
			try {
				byte[] b = streamBr.ReadBytes(4);
				if (b[0] != 'R' || b[1] != 'I' || b[2] != 'F' || b[3] != 'F') {
					return false;
				}

				// 全体サイズは読み込みサイズで判定するので無視
				streamBr.BaseStream.Seek(4, SeekOrigin.Current);

				b = streamBr.ReadBytes(4);
				if (b[0] != 'W' || b[1] != 'A' || b[2] != 'V' || b[3] != 'E') {
					return false;
				}

				// WAVEチャンク内にfmtチャンクが見つかるまでチャンクを読み捨てる
				while (true) {
					b = streamBr.ReadBytes(4);
					if (b[0] == 'f' && b[1] == 'm' && b[2] == 't' && b[3] == ' ') {
						break;
					} else {
						long n = streamBr.ReadUInt32();
						streamBr.BaseStream.Seek(n, SeekOrigin.Current);
					}
				}

				// ヘッダー読み込み
				long cksize = streamBr.ReadUInt32();
				short tag = streamBr.ReadInt16();

				waveFormat.FormatTag = tag;
				waveFormat.Channels = streamBr.ReadInt16();
				waveFormat.SamplesPerSecond = streamBr.ReadInt32();
				waveFormat.AverageBytesPerSecond = streamBr.ReadInt32();
				waveFormat.BlockAlign = streamBr.ReadInt16();
				waveFormat.BitsPerSample = streamBr.ReadInt16();

				if (cksize > 16) {
					if (cksize == 40 && waveFormat.FormatTag == WaveFormatTag.EXTENSIBLE) {
						short size = streamBr.ReadInt16();
						if (size != 22) {
							return false;
						}
						waveFormat.Extensible = true;
						waveFormat.Samples = streamBr.ReadInt16();
						waveFormat.ChannelMask = streamBr.ReadUInt32();
						waveFormat.SubFormat = streamBr.ReadBytes(16);
					} else {
						// 不要データの読み飛ばし
						streamBr.BaseStream.Seek(cksize - 16, SeekOrigin.Current);
					}
				}

				// ストリーム開始位置
				b = streamBr.ReadBytes(4);
				if (b[0] != 'd' || b[1] != 'a' || b[2] != 't' || b[3] != 'a') {
					return false;
				}

				// 有効ストリームサイズ
				cksize = streamBr.ReadUInt32();
				streamOffset = streamBr.BaseStream.Position;
				if (streamOffset + cksize > streamBr.BaseStream.Length) {
					streamLength = streamBr.BaseStream.Length - streamOffset;
				} else {
					streamLength = cksize;
				}

				// ストリーム先頭へ
				SeekStream(0, SeekOrigin.Begin);

			} catch (Exception) {   // 乱暴だがこれで問題になる状況はよほどの状況
				return false;
			}
			return true;
		}

		public byte[] Read(int n)
		{
			return streamBr.ReadBytes(n);
		}

		public long SeekStream(long n, SeekOrigin origin)
		{
			if (origin == SeekOrigin.Begin) {
				if (n < 0 || n > streamLength) {
					return -1;
				}
				return streamFs.Seek(n + streamOffset, origin);
			} else if (origin == SeekOrigin.Current) {
				if (n + streamFs.Position < streamOffset || streamOffset + streamLength >= n + streamFs.Position) {
					return -1;
				}
				return streamFs.Seek(n, origin);
			}
			return -1;
		}

		/// <summary>
        /// ファイルをクローズします。
        /// </summary>
		public void Close()
		{
			Dispose();
		}

		#region Dispose Finalize Pattern

        /// <summary>
        /// 既にDisposeメソッドが呼び出されているかどうかを表します。
        /// </summary>
        private bool disposed;

        /// <summary>
        /// このクラスのインスタンスによって使用されているすべてのリソースを解放します。
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Dispose(true);
        }

        /// <summary>
        /// このクラスのインスタンスがGCに回収される時に呼び出されます。
        /// </summary>
		~RiffReader()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// RiffWriter によって使用されているアンマネージ リソースを解放し、オプションでマネージ リソースも解放します。
        /// </summary>
        /// <param name="disposing">マネージ リソースとアンマネージ リソースの両方を解放する場合は true。アンマネージ リソースだけを解放する場合は false。 </param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed) {
                return;
            }
            this.disposed = true;

            if (disposing) {
                // マネージ リソースの解放処理をこの位置に記述します。
				if (streamFs != null) {
					streamFs.Close();
					streamFs = null;
				}
				if (streamBr != null) {
					streamBr.Close();
					streamBr = null;
				}
            }
            // アンマネージ リソースの解放処理をこの位置に記述します。
        }

        /// <summary>
        /// 既にDisposeメソッドが呼び出されている場合、例外をスローします。
        /// </summary>
        /// <exception cref="System.ObjectDisposedException">既にDisposeメソッドが呼び出されています。</exception>
        protected void ThrowExceptionIfDisposed()
        {
            if (this.disposed) {
                throw new ObjectDisposedException(this.GetType().FullName);
            }
        }

        /// <summary>
        /// Dispose Finalize パターンに必要な初期化処理を行います。
        /// </summary>
        private void InitializeDisposeFinalizePattern()
        {
            this.disposed = false;
        }

        #endregion

		#region Object派生

		/// <summary>
		/// ハッシュコードを取得します。オープンしているファイルに基づくハッシュコードです。
		/// </summary>
		/// <returns>ハッシュ値</returns>
		public override int GetHashCode()
		{
			return FilePath.GetHashCode();
		}
		/// <summary>
		/// 文字列表現を取得します。
		/// </summary>
		/// <returns>文字列表現</returns>
		public override string ToString()
		{
			return FilePath;
		}

		#endregion
    }
}
