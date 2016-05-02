using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.Search
{
    public class DepthFirstSearch : ASearchingAlgorithm
    {
        private Stack<AState> m_openList;
        private int countOfStates=1;

        public DepthFirstSearch()
        {
            m_openList = new Stack<AState>();
        }

        protected override void ClearOpenClosedLists()
        {
            m_openList.Clear();
            base.ClearOpenClosedLists();
        }

        public override bool IsEmptyOpenList()
        {
            return (m_openList.Count == 0);
        }

        public override int GetOpenListSize()
        {
            return m_openList.Count;
        }

        public override Solution Solve(ISearchable searchDomain)
        {
            StartMeasureTime();
            ClearOpenClosedLists();
            AddToOpenList(searchDomain.GetStartState());

            Solution solution = new Solution();
            AState goalState = searchDomain.GetGoalState();
            AState state;
            IEnumerable<AState> stateSuccessors;
            while (!IsEmptyOpenList())
            {
                state = PopOpenList();
                AddToClosedList(state);
                if (state.Equals(goalState))
                {
                    solution = BacktrackSolution(state);
                    break;
                }
                else
                {
                    stateSuccessors = searchDomain.GetAllSuccessors(state);
                    foreach (AState successor in stateSuccessors)
                    {
                        if (!IsStateInClosedList(successor))
                        {
                            AddToOpenList(successor); 
                        }
                    }
                }
            }
            StopMeasureTime();
            return solution;
        }

        public override void AddToOpenList(AState state)
        {
            if (!m_openListStates.ContainsKey(state.GetState()))
            {
                m_openList.Push(state);
                m_openListStates.Add(state.GetState(), state);
                countOfStates++;
            }
        }

        public override AState PopOpenList()
        {
            AState popedState = m_openList.Pop();
            m_openListStates.Remove(popedState.GetState());
            return popedState;
        }

        public override int GetNumberOfGeneratedNodes()
        {
            return countOfStates;
        }

    }
}
