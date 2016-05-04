using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.Search
{
    /// <summary>
    /// an interface of an isearchable object
    /// </summary>
    public interface ISearchable
    {
        /// <summary>
        /// get the start state
        /// </summary>
        /// <returns>astate</returns>
        AState GetStartState();
        /// <summary>
        /// get the goal state
        /// </summary>
        /// <returns> goal astate</returns>
        AState GetGoalState();
        /// <summary>
        /// to get all the successors
        /// </summary>
        /// <param name="state"></param>
        /// <returns> IEnumerable database of all successors </returns>
        IEnumerable<AState> GetAllSuccessors(AState state);
    }
}
