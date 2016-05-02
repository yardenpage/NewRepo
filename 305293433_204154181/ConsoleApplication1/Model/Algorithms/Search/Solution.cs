using ATP2016Project.Model.Algorithms.Search;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.Search
{
    public class Solution
    {
        private ArrayList m_solutionPath;
        /// <summary>
        /// a solution constructor
        /// </summary>
        public Solution()
        {
            m_solutionPath = new ArrayList();
        }
        /// <summary>
        /// add a new state to the solution arrayList
        /// </summary>
        /// <param name="state"> a new state to add</param>
        public void AddState(AState state)
        {
            m_solutionPath.Add(state);
        }
        /// <summary>
        /// check if the arraylist of the solution is not empty
        /// </summary>
        /// <returns>true or false if there is a solution</returns>
        public bool IsSolutionExists()
        {
            return m_solutionPath.Count > 0;
        }
        /// <summary>
        /// check how many steps to the solution
        /// </summary>
        /// <returns>num of steps</returns>
        public int GetSolutionSteps()
        {
            return m_solutionPath.Count;
        }
        /// <summary>
        /// get the arraylist of steps of the solution
        /// </summary>
        /// <returns>the solution path</returns>
        public ArrayList GetSolutionPath()
        {
            return m_solutionPath;
        }
        /// <summary>
        /// doing a reverse to the arraylist states
        /// </summary>
        public void RevereseSolution()
        {
            m_solutionPath.Reverse();
        }
    }
}
