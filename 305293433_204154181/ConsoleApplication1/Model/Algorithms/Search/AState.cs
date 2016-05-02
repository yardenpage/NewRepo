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
        protected double m_g;
        protected double m_cost;
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

        public int CompareTo(AState state)
        {
            return m_cost.CompareTo(state.GetCost());
        }

        public bool Equals(AState state)
        {
            return m_state.Equals(state.GetState());
        }

        public double GetG()
        {
            return m_g;
        }

        public void SetG(double g)
        {
            m_g = g;
        }

        public double GetCost()
        {
            return m_cost;
        }

        public void SetCost(double cost)
        {
            m_cost = cost;
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

    }
}
