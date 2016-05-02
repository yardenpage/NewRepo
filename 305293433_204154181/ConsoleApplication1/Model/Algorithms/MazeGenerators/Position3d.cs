using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.MazeGenerators
{
    public class Position3d : Position
    {

        /// <summary>
        /// three corrdinates constructor
        /// </summary>
        /// <param name="x"> width </param>
        /// <param name="y">length </param>
        /// <param name="z"> height </param>
        public Position3d(int x, int y, int z) : base()
        {
            position.Add(x);
            position.Add(y);
            position.Add(z);
        }
        /// <summary>
        /// property of the height
        /// </summary>
        public int z
        {
            get
            {
                return (int)position[2];
            }
            set
            {
                position[2] = value;
            }
        }
        /// <summary>
        /// check if two positions are equal
        /// </summary>
        /// <param name="obj"> the position to compare </param>
        /// <returns> true/false </returns>
        public override bool Equals(object obj)
        {
            Position3d comp = (obj as Position3d);
            // convert to object to Position type and cheak if the three corrdinate are equale
            return (x == comp.x && y == comp.y && z == comp.z);
        }
        /// <summary>
        /// a function use to compare
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return GetHashCode();
        }
        /// <summary>
        /// print the position 
        /// </summary>
        public override void print()
        {
            Console.WriteLine("(" + position[0] + "," + position[1] + "," + position[2] + ")");
        }
        /// <summary>
        /// return a string with the position
        /// </summary>
        /// <returns> a string with the position </returns>
        public override string getPrint()
        {
            string p = "(" + position[0] + "," + position[1] + "," + position[2] + ")";
            return p;
        }

    }
}
