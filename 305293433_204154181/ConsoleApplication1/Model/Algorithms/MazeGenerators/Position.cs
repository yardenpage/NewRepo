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
        public Position()//empty conatructor
        {
            position = new ArrayList();
        }
        public Position(ArrayList points)// constractor with parameters
        {
            position = new ArrayList();
        }

        //geters and setters to the corrdinates
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

        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();
        public abstract void print();
        public abstract string getPrint();
    }
}
