using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.Compression
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICompressor
    {
        /// <summary>
        /// get decompress data to compress
        /// </summary>
        /// <param name="data"> data to compress</param>
        /// <returns>compress data</returns>
        byte[] compress(byte[] data);
        /// <summary>
        /// get compress data bytes
        /// </summary>
        /// <param name="data"> data to decompress</param>
        /// <returns> decompress data</returns>
        byte[] decompress(byte[] data);
    }
}
