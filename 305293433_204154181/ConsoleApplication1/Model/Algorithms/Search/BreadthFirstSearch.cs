using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.Search
{
    /// <summary>
    /// a class that inherite ASearchingAlgorithm
    /// </summary>
    public class BreadthFirstSearch : ASearchingAlgorithm
    {
        /// <summary>
        /// a queue of state we just discover
        /// </summary>
        private Queue<AState> m_openList;

        /// <summary>
        /// an empty constructor 
        /// </summary>
        public BreadthFirstSearch()
        {
            m_openList = new Queue<AState>();
        }
        /// <summary>
        /// clear thr open and close lists
        /// </summary>
        protected override void ClearOpenClosedLists()
        {
            m_openList.Clear();
            base.ClearOpenClosedLists();
        }
        /// <summary>
        /// check if the open list is empty
        /// </summary>
        /// <returns> true/false </returns>
        public override bool IsEmptyOpenList()
        {
            return (m_openList.Count == 0);
        }
        /// <summary>
        /// get the size of the open lisr
        /// </summary>
        /// <returns> the size of the open list </returns>
        public override int GetOpenListSize()
        {
            return m_openList.Count;
        }
        /// <summary>
        /// solve the maze
        /// </summary>
        /// <param name="searchDomain"> the maze to solve </param>
        /// <returns> a solyution of the maze </returns>
        public override Solution Solve(ISearchable searchDomain)
        {
            StartMeasureTime();
            ClearOpenClosedLists();
            countOfStates = 0;
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
        /// <summary>
        /// add a state to the open list
        /// </summary>
        /// <param name="state"> the state to add </param>
        public override void AddToOpenList(AState state)
        {
            if (!m_openListStates.ContainsKey(state.GetState()))
            {
                m_openListStates.Add(state.GetState(), state);
                m_openList.Enqueue(state);
                countOfStates++;
            }  
        }
        /// <summary>
        /// take the last state that insert to the open list
        /// </summary>
        /// <returns> a state s</returns>
        public override AState PopOpenList()
        {
            AState popedState = m_openList.Dequeue();
            m_openListStates.Remove(popedState.GetState());
            return popedState;
        }
        /// <summary>
        /// get the number of state that visited
        /// </summary>
        /// <returns> number of states </returns>
        public override int GetNumberOfGeneratedNodes()
        {
            return countOfStates;
        }
    }
}
