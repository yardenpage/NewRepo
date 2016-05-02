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

        //three corrdinates constructor
        public Position3d(int x, int y, int z) : base()
        {
            position.Add(x);
            position.Add(y);
            position.Add(z);
        }

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

        public override bool Equals(object obj)
        {
            Position3d comp = (obj as Position3d);
            // convert to object to Position type and cheak if the three corrdinate are equale
            return (x == comp.x && y == comp.y && z == comp.z);
        }
        public override int GetHashCode()
        {
            return GetHashCode();
        }

        public override void print()
        {
            Console.WriteLine("(" + position[0] + "," + position[1] + "," + position[2] + ")");
        }
        public override string getPrint()
        {
            string p = "(" + position[0] + "," + position[1] + "," + position[2] + ")";
            return p;
        }

    }
}
