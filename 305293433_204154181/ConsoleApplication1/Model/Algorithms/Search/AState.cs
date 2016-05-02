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

        public AState(AState parentState)
        {
            m_parentsState = new List<AState>();
            if (parentState != null)
            {
                m_parentsState.AddRange(parentState.GetParentState());
                AddToParentList(parentState);
            }
        }

        private void AddToParentList(AState state)
        {
            m_parentsState.Add(state);
        }

        public bool Equals(AState state)
        {
            return m_state.Equals(state.GetState());
        }

        public string GetState()
        {
            return m_state;
        }

        public List<AState> GetParentState()
        {
            return m_parentsState;
        }

        public abstract void PrintState();

        public abstract void PrintCorrdinates();

        public int CompareTo(AState other)
        {
            throw new NotImplementedException();
        }
    }
}
