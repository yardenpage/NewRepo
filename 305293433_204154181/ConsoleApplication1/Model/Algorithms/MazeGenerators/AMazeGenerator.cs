using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.MazeGenerators
{
    public abstract class AMazeGenerator : IMazeGenerator
    {
        /// <summary>
        /// Abstract maze generator
        /// </summary>
        protected ArrayList m_points;
        /// <summary>
        /// constructor AMazeGenerator - creates a new arraylist
        /// </summary>
        public AMazeGenerator()
        {
            m_points = new ArrayList();
        }
        /// <summary>
        /// abstract generate method
        /// </summary>
        /// <param name="points"> array of the corrdinates</param>
        /// <returns> a maze </returns>
        public abstract AMaze generate(ArrayList points);
        /// <summary>
        /// calculates the running time of the algorithm
        /// </summary>
        /// <param name="points"> array of the corrdinates </param>
        /// <returns> string of the time </returns>
        public string measureAlgorithmTime(ArrayList points) // return the time takes the generate algorithem to run
        {
            string runningTime = "";
            double ans = 0;
            DateTime clockTime = DateTime.Now;//take time before generate
            generate(points);// the function we want to measure
            DateTime clockTimeAfterGenerate = DateTime.Now;//take time after generate
            TimeSpan runningT = clockTimeAfterGenerate - clockTime;//calculate the differance
            ans = runningT.TotalMilliseconds;//get the time at miliseconds
            runningTime = System.Convert.ToString(ans);//convert the time to int
            runningTime = "Running time (miliseconds): "+ runningTime;
            return runningTime;
        }
        /// <summary>
        /// property of the arraylist corrdinates
        /// </summary>
        public ArrayList points
        {
            get
            {
                return m_points;
            }
            set
            {
                m_points = value;
            }
        }
    }
}
