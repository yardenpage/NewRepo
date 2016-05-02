using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.Search
{
    public abstract class AState : IComparable<AState>
    {
        protected string m_state;
        protected List<AState> m_parentsState;
        /// <summary>
        /// constructor of a state
        /// </summary>
        /// <param name="parentState">the state of the parent</param>
        public AState(AState parentState)
        {
            m_parentsState = new List<AState>();
            if (parentState != null)
            {
                m_parentsState.AddRange(parentState.GetParentState());
                AddToParentList(parentState);
            }
        }
        /// <summary>
        /// add a state to the list of the parents
        /// </summary>
        /// <param name="state"></param>
        private void AddToParentList(AState state)
        {
            m_parentsState.Add(state);
        }
 
        /// <summary>
        /// check if 2 states are equal
        /// </summary>
        /// <param name="state">the state to compare</param>
        /// <returns>true if equals else false</returns>
        public bool Equals(AState state)
        {
            return m_state.Equals(state.GetState());
        }
        /// <summary>
        /// return the string of the state
        /// </summary>
        /// <returns>string of the state</returns>
        public string GetState()
        {
            return m_state;
        }
        /// <summary>
        /// get the list of the parents of the state
        /// </summary>
        /// <returns>the parents list</returns>
        public List<AState> GetParentState()
        {
            return m_parentsState;
        }
        /// <summary>
        /// print the state
        /// </summary>
        public abstract void PrintState();

        public abstract void PrintCorrdinates();

        public int CompareTo(AState other)
        {
            throw new NotImplementedException();
        }
    }
}
