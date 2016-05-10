using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.Compression
{
    public class MyMaze3DCompressor : ICompressor
    {
        /// <summary>
        /// get a data of a 3D maze
        /// </summary>
        /// <param name="data">a maze</param>
        /// <returns> a compress data of the maze</returns>
        public byte[] compress(byte[] data)
        {
            List<byte> compressed = new List<byte>();
            int i = 0;
            while (i < data.Length)
            {
                byte b = data[i]; // current data
                compressed.Add(b); // put it in
                i++;
                // how many times it appears continuously?
                byte count = 0;
                while (i < data.Length && data[i] == b && count < byte.MaxValue) { count++; i++; }
                // write that count;
                compressed.Add(count);
            }
            // return the compressed array
            return compressed.ToArray();
        }
        /// <summary>
        /// get a compress data of 3D maze
        /// </summary>
        /// <param name="data"> a compress maze</param>
        /// <returns>decompress maze</returns>
        public byte[] decompress(byte[] data)
        {
            List<byte> decompressed = new List<byte>();
            int i = 0;
            while (i < data.Length)
            {
                byte b = data[i];
                decompressed.Add(b);
                i++;
                for (int j=0; j<data[i]; j++)
                {
                    decompressed.Add(b);
                }
                i++;
            }
            return decompressed.ToArray();
        }
    }
}
