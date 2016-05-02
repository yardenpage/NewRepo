using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.Search
{
    public abstract class ASearchingAlgorithm : ISearchingAlgorithm
    {
        protected Dictionary<string, AState> m_openListStates;
        protected Dictionary<String, AState> m_closedList;
        private Stopwatch m_stopWatch;

        public ASearchingAlgorithm()
        {
            m_openListStates = new Dictionary<string, AState>();
            m_closedList = new Dictionary<string, AState>();
            m_stopWatch = new Stopwatch();
        }

        public abstract Solution Solve(ISearchable searchDomain);

        protected virtual void ClearOpenClosedLists()
        {
            m_openListStates.Clear();
            m_closedList.Clear();
        }
 
        protected bool IsStateInOpenList(AState state)
        {
            return m_openListStates.ContainsKey(state.GetState());
        }

        public abstract bool IsEmptyOpenList();


        public abstract int GetOpenListSize();


        protected void AddToClosedList(AState state)
        {
            if (!m_closedList.ContainsKey(state.GetState()))
            {
                m_closedList.Add(state.GetState(), state);
            }
        }

        protected bool IsStateInClosedList(AState state)
        {
            return m_closedList.ContainsKey(state.GetState());
        }

        public abstract int GetNumberOfGeneratedNodes();

        public abstract void AddToOpenList(AState state);

        public abstract AState PopOpenList();

        public Solution BacktrackSolution(AState goal)
        {
            Solution solution = new Solution();
            List<AState> parentState = goal.GetParentState();
            for (int i = 0; i < parentState.Count; i++)
            {
                solution.AddState(parentState[i]);
            }

            //solution.RevereseSolution();
            return solution;
        }

        public void StartMeasureTime()
        {
            m_stopWatch.Restart();
        }

        public void StopMeasureTime()
        {
            m_stopWatch.Stop();
        }

        public double GetSolvingTimeMiliseconds()
        {
            return m_stopWatch.ElapsedTicks;
        }

    }
}
