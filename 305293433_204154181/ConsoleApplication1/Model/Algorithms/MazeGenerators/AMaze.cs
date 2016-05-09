using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.MazeGenerators
{
    public abstract class AMaze : IMaze
    {
        /// <summary>
        /// abstract maze
        /// </summary>
        protected Position start;
        protected Position end;
        /// <summary>
        ///  get the start position 
        /// </summary>
        /// <returns> start </returns>
        public Position getStartPosition()
        {
            return start;
        }
        /// <summary>
        /// get the goal position
        /// </summary>
        /// <returns> end </returns>
        public Position getGoalPosition()
        {
            return end;
        }
        /// <summary>
        /// property start position
        /// </summary>
        public Position Start
        {
            get
            {
                return start;
            }
            set
            {
                start = value;
            }
        }
        /// <summary>
        /// property goal position
        /// </summary>
        public Position End
        {
            get
            {
                return end;
            }
            set
            {
                end = value;
            }
        }
        /// <summary>
        /// abstract print function
        /// </summary>
        public abstract void print();

        public abstract List<byte> getPrint();
    }
}