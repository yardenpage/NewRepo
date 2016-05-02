using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.Search
{
    public class BreadthFirstSearch : ASearchingAlgorithm
    {
        private Queue<AState> m_openList;
        private int countOfStates=1;

        public BreadthFirstSearch()
        {
            m_openList = new Queue<AState>();
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
                m_openListStates.Add(state.GetState(), state);
                m_openList.Enqueue(state);
                countOfStates++;
            }  
        }

        public override AState PopOpenList()
        {
            AState popedState = m_openList.Dequeue();
            m_openListStates.Remove(popedState.GetState());
            return popedState;
        }

        public override int GetNumberOfGeneratedNodes()
        {
            return countOfStates;
        }
    }
}
