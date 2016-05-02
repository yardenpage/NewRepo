using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.MazeGenerators
{
    public abstract class Position
    {
        
        //array to hold the corrdinates
        protected ArrayList position;
        /// <summary>
        /// an empty constructor of a position
        /// </summary>
        public Position()//empty constructor
        {
            position = new ArrayList();
        }
        /// <summary>
        /// a constructor of a position with given points
        /// </summary>
        /// <param name="points">corrdinates of the position</param>
        public Position(ArrayList points)// constractor with parameters
        {
            position = new ArrayList();
        }
        /// <summary>
        /// property of the width
        /// </summary>
        public int x
        {
            get
            {
                return (int)position[0];
            }
            set
            {
                position[0] = value;
            }
        }
        /// <summary>
        /// property of the length
        /// </summary>
        public int y
        {
            get
            {
                return (int)position[1];
            }
            set
            {
                position[1] = value;
            }
        }
        /// <summary>
        /// check if two positions are equal
        /// </summary>
        /// <param name="obj"> the position to compare</param>
        /// <returns></returns>
        public abstract override bool Equals(object obj);
        /// <summary>
        /// a function uses to compare
        /// </summary>
        /// <returns></returns>
        public abstract override int GetHashCode();
        /// <summary>
        /// print the position
        /// </summary>
        public abstract void print();
        /// <summary>
        /// return a string with the position
        /// </summary>
        /// <returns> string of the position </returns>
        public abstract string getPrint();
    }
}
