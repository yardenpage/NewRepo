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

        public Solution()
        {
            m_solutionPath = new ArrayList();
        }

        public void AddState(AState state)
        {
            m_solutionPath.Add(state);
        }

        public bool IsSolutionExists()
        {
            return m_solutionPath.Count > 0;
        }

        public int GetSolutionSteps()
        {
            return m_solutionPath.Count;
        }

        public ArrayList GetSolutionPath()
        {
            return m_solutionPath;
        }

        public void RevereseSolution()
        {
            m_solutionPath.Reverse();
        }
    }
}
