using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.Compression
{
    public class MyCompressorStream : Stream
    {
        /// <summary>
        /// enum that repesents if the mode is compress or decompress
        /// </summary>
        public enum status { compress = 0, decompress = 1 };
        /// <summary>
        /// the size of the bytes array
        /// </summary>
        private const int m_BufferSize = 100;
        /// <summary>
        /// the bytes array
        /// </summary>
        private byte[] m_bytesReadFromStream;
        /// <summary>
        /// 
        /// </summary>
        private Queue<byte> m_queue;
        /// <summary>
        /// a adapation of compressor 3D maze
        /// </summary>
        private MyMaze3DCompressor m_mymaze3DCompressor;
        /// <summary>
        /// the current stream
        /// </summary>
        private Stream m_io;
        /// <summary>
        /// the current mode
        /// </summary>
        private status m_mode;
        //private FileStream fileInStream;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="io"> the stream of data</param>
        /// <param name="mode">the mode of the stream</param>

        public MyCompressorStream(Stream io, status mode)
        {
            this.m_io = io;
            this.m_mode = mode;
            m_bytesReadFromStream = new byte[m_BufferSize];
            m_queue = new Queue<byte>();
            m_mymaze3DCompressor = new MyMaze3DCompressor();
        }

        //public MyCompressorStream(FileStream fileInStream)
        //{
        //    this.fileInStream = fileInStream;
        //}

        /// <summary>
        /// property of the status mode
        /// </summary>
        public status mode
        {
            get
            {
                return m_mode;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public override bool CanRead
        {
            get
            {
                return m_io.CanRead;
            }
        }

        public override bool CanSeek
        {
            get
            {
                return m_io.CanSeek;
            }
        }

        public override bool CanWrite
        {
            get
            {
                return m_io.CanWrite;
            }
        }

        public override long Length
        {
            get
            {
                return m_io.Length;
            }
        }

        public override long Position
        {
            get
            {
                return m_io.Position;
            }

            set
            {
                m_io.Position = value;
            }
        }

        public override void Flush()
        {
            m_io.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (m_mode == status.compress)
            {
                int r = 0;
                while (m_queue.Count < count && (r = m_io.Read(m_bytesReadFromStream, 0, m_BufferSize)) != 0)
                {
                    // our source actually contain R bytes and if R<bufferSize then the rest of bytes are leftovers... 
                    // let's cut them
                    byte[] data = new byte[r];
                    for (int i = 0; i < r; data[i] = m_bytesReadFromStream[i], i++) ;

                    byte[] compressed = m_mymaze3DCompressor.compress(data);
                    // now, we'll put the decomprssed data in the queue; it is used as a buffer
                    foreach (byte b in compressed)
                    {
                        m_queue.Enqueue(b);
                    }
                    Array.Clear(m_bytesReadFromStream, 0, m_bytesReadFromStream.Length);

                }
                int bytesCount = Math.Min(m_queue.Count, count);

                for (int i = 0; i < bytesCount; i++)
                {
                    buffer[i + offset] = m_queue.Dequeue();
                }
                return bytesCount;
            }
            else if (m_mode == status.decompress)
            {
                // we should read X < Count compressed bytes form the source stream
                // and allow the reader to read COUNT decomprssed bytes from buffer
                // starting from OFFSET index

                int r = 0;
                while (m_queue.Count < count && (r = m_io.Read(m_bytesReadFromStream, 0, m_BufferSize)) != 0)
                {
                    // our source actually contain R bytes and if R<bufferSize then the rest of bytes are leftovers... 
                    // let's cut them
                    byte[] data = new byte[r];
                    for (int i = 0; i < r; data[i] = m_bytesReadFromStream[i], i++) ;

                    byte[] decompressed = m_mymaze3DCompressor.decompress(data);
                    // now, we'll put the decomprssed data in the queue; it is used as a buffer
                    foreach (byte b in decompressed)
                    {
                        m_queue.Enqueue(b);
                    }
                    Array.Clear(m_bytesReadFromStream, 0, m_bytesReadFromStream.Length);
                }
                int bytesCount = Math.Min(m_queue.Count, count);

                for (int i = 0; i < bytesCount; i++)
                {
                    buffer[i + offset] = m_queue.Dequeue();
                }
                return bytesCount;
            }
            return 0;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return m_io.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            m_io.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            List<byte> list = new List<byte>();
            int stopPoint = offset;
            int range = count;
            Array.Clear(m_bytesReadFromStream, 0, m_bytesReadFromStream.Length);
            if (m_mode == MyCompressorStream.status.compress)
            {
                while (range > 0)
                {
                    if (range <= m_BufferSize)
                    {
                        for (int j = 0; j < range; j++)
                        {
                            m_bytesReadFromStream[j] = buffer[stopPoint];
                            stopPoint++;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < m_BufferSize; j++)
                        {
                            m_bytesReadFromStream[j] = buffer[stopPoint];
                            stopPoint++;
                        }
                    }
                    byte[] compressed = m_mymaze3DCompressor.compress(m_bytesReadFromStream);
                    // now, we'll put the decomprssed data in the queue; it is used as a buffer
                    foreach (byte b in compressed)
                    {
                        m_queue.Enqueue(b);
                    }
                    range = count - stopPoint + offset;
                    Array.Clear(m_bytesReadFromStream, 0, m_bytesReadFromStream.Length);
                }
            }

            if (m_mode == MyCompressorStream.status.decompress)
            {
                while (range > 0)
                {
                    if (range <= m_BufferSize)
                    {
                        for (int j = 0; j < range; j++)
                        {
                            m_bytesReadFromStream[j] = buffer[stopPoint];
                            stopPoint++;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < m_BufferSize; j++)
                        {
                            m_bytesReadFromStream[j] = buffer[stopPoint];
                            stopPoint++;
                        }
                    }
                    byte[] decompressed = m_mymaze3DCompressor.decompress(m_bytesReadFromStream);
                    // now, we'll put the decomprssed data in the queue; it is used as a buffer
                    foreach (byte b in decompressed)
                    {
                        m_queue.Enqueue(b);
                    }
                    range = count - stopPoint + offset;
                    Array.Clear(m_bytesReadFromStream, 0, m_bytesReadFromStream.Length);
                }
            }

            byte[] a = new byte[m_queue.Count];
            for (int i = 0; i < m_queue.Count; i++)
            {
                a[i] = m_queue.Dequeue();
            }

            m_io.Write(a, 0, a.Length);
        }
    }
}
