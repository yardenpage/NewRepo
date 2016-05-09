using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.MazeGenerators
{
    public class Cell
    {
        public enum status { path = 0, wall = 1, border = 2 };
        public enum Visit { notvisit = 0, visit = 1 };
        private status myValue;// 0/1 the value of the current squre
        private Visit Visited;

        private Position2d position;
        /// <summary>
        /// constructor of a cell
        /// </summary>
        /// <param name="x"> corrdinate of the width </param>
        /// <param name="y"> corrdinate of the length </param>
        public Cell(int x, int y)//constructor initiate it's corrdinate;
        {
            myValue = status.border;
            Visited = Visit.notvisit;
            position = new Position2d(x, y);
        }
        /// <summary>
        /// property of the visit value
        /// </summary>
        public Visit visit
        {
            get
            {
                return Visited;
            }
            set
            {
                Visited = value;
            }
        }
        /// <summary>
        /// property of the position value
        /// </summary>
        public Position2d Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }
        /// <summary>
        /// property of the cell value
        /// </summary>
        public status myvalue
        {
            get
            {
                return myValue;
            }
            set
            {
                myValue = value;
            }
        }

    }
}
