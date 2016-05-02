using ATP2016Project.Model.Algorithms.MazeGenerators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.MazeGenerators
{
    public class Position2d : Position
    {
        /// <summary>
        /// two corrdinate constractor
        /// </summary>
        /// <param name="x"> width </param>
        /// <param name="y"> length </param>
        public Position2d(int x, int y) : base()
        {
            position.Add(x);
            position.Add(y);
        }
        /// <summary>
        /// compare two corrdinates
        /// </summary>
        /// <param name="obj"> the corrdinate to compare </param>
        /// <returns> true/ false </returns>
        public override bool Equals(object obj)
        {
            Position2d comp = (obj as Position2d);
            // convert to object to Position type and cheak if the three corrdinate are equale
            return (x == comp.x && y == comp.y);
        }
        /// <summary>
        /// a function uses for compare
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return GetHashCode();
        }
        /// <summary>
        /// print the corrdinate
        /// </summary>
        public override void print()
        {
            Console.WriteLine("(" + position[0] + "," + position[1] + ")");
        }
        /// <summary>
        /// return a string with the corrdinate
        /// </summary>
        /// <returns> a string with the corrdinate </returns>
        public override string getPrint()
        {
            string p="(" + position[0] + "," + position[1] + ")";
            return p;
        }
    }
}