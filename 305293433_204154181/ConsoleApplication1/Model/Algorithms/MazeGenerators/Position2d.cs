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
        //two corrdinate constractor
        public Position2d(int x, int y) : base()
        {
            position.Add(x);
            position.Add(y);
        }
        public override bool Equals(object obj)
        {
            Position2d comp = (obj as Position2d);
            // convert to object to Position type and cheak if the three corrdinate are equale
            return (x == comp.x && y == comp.y);
        }

        public override int GetHashCode()
        {
            return GetHashCode();
        }

        public override void print()
        {
            Console.WriteLine("(" + position[0] + "," + position[1] + ")");
        }

        public override string getPrint()
        {
            string p="(" + position[0] + "," + position[1] + ")";
            return p;
        }
    }
}