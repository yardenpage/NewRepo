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
            if (data[i] == '1')
            {
                compressed.Add(0);
            }
            while (i < data.Length)
            {
                byte b = data[i]; // current data
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
            byte value =  0;
            while (i < data.Length)
            {
                byte b = data[i];
                for(int j=0; j<data[i]; j++)
                {
                    decompressed.Add(value);
                }
                i++;
                value=(value==0) ? (byte)1 : (byte)0;
            }
            return decompressed.ToArray();
        }
    }
}
