﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.Search
{
    /// <summary>
    /// class of ASearchingAlgorithm that implement ISearchingAlgorithm interface
    /// </summary>
    public abstract class ASearchingAlgorithm : ISearchingAlgorithm
    {
        /// <summary>
        /// a data base that handle the new states we arrive
        /// </summary>
        protected Dictionary<string, AState> m_openListStates;
        /// <summary>
        /// a data base that handle the states we finish to deal with
        /// </summary>
        protected Dictionary<String, AState> m_closedList;
        /// <summary>
        /// a watch to measure the time
        /// </summary>
        private Stopwatch m_stopWatch;
        /// <summary>
        ///  counter of the all developed states
        /// </summary>
        protected int countOfStates;
        /// <summary>
        /// constructor of ASearchingAlgorithm
        /// </summary>
        protected Boolean stopFlag = false;
        public ASearchingAlgorithm()
        {
            m_openListStates = new Dictionary<string, AState>();
            m_closedList = new Dictionary<string, AState>();
            m_stopWatch = new Stopwatch();
        }
        /// <summary>
        /// an abstract function to solve the maze
        /// </summary>
        /// <param name="searchDomain">an algorithm to solve the maze</param>
        /// <returns>the solution of the maze</returns>
        public abstract Solution Solve(ISearchable searchDomain);
        /// <summary>
        /// function that delete the openList
        /// </summary>
        protected virtual void ClearOpenClosedLists()
        {
            m_openListStates.Clear();
            m_closedList.Clear();
        }
        /// <summary>
        /// check if a state is in the open list
        /// </summary>
        /// <param name="state"></param>
        /// <returns>true if exist or false</returns>
        protected bool IsStateInOpenList(AState state)
        {
            return m_openListStates.ContainsKey(state.GetState());
        }
        /// <summary>
        /// check if the open list length is 0
        /// </summary>
        /// <returns>true if empty or false</returns>
        public abstract bool IsEmptyOpenList();

        /// <summary>
        /// check how many states exist in the open list
        /// </summary>
        /// <returns>number of states</returns>
        public abstract int GetOpenListSize();

        /// <summary>
        /// add a state to the close list
        /// </summary>
        /// <param name="state">state to add</param>
        protected void AddToClosedList(AState state)
        {
            if (!m_closedList.ContainsKey(state.GetState()))
            {
                m_closedList.Add(state.GetState(), state);
            }
        }
        /// <summary>
        /// check if a state is in the close list
        /// </summary>
        /// <param name="state">the state to check</param>
        /// <returns>return true if exist or fase</returns>
        protected bool IsStateInClosedList(AState state)
        {
            return m_closedList.ContainsKey(state.GetState());
        }
        /// <summary>
        /// get the number of all developed states
        /// </summary>
        /// <returns> number of states </returns>
        public int GetNumberOfGeneratedNodes()
        {
            return countOfStates;
        }
        /// <summary>
        /// add a state to the OpenList
        /// </summary>
        /// <param name="state"></param>
        public abstract void AddToOpenList(AState state);
        /// <summary>
        /// pop a state from the OpenList
        /// </summary>
        /// <returns> state</returns>
        public abstract AState PopOpenList();
        /// <summary>
        /// create the solution list
        /// </summary>
        /// <param name="goal"></param>
        /// <returns>the solution</returns>
        public Solution BacktrackSolution(AState goal)
        {
            Solution solution = new Solution();
            List<AState> parentState = goal.GetParentState();
            for (int i = 0; i < parentState.Count; i++)
            {
                solution.AddState(parentState[i]);
            }
            solution.AddState(goal);
            return solution;
        }
        /// <summary>
        /// open the clock
        /// </summary>
        public void StartMeasureTime()
        {
            m_stopWatch.Restart();
        }
        /// <summary>
        /// stop the watch 
        /// </summary>
        public void StopMeasureTime()
        {
            m_stopWatch.Stop();
        }
        /// <summary>
        /// get the time of solving the algorithm
        /// </summary>
        /// <returns>the time of solving the algorithm</returns>
        public double GetSolvingTimeMiliseconds()
        {
            return m_stopWatch.Elapsed.TotalMilliseconds;
        }

        public abstract void stop();
    }
}
