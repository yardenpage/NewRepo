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
        AState GetStartState();
        AState GetGoalState();
        IEnumerable<AState> GetAllSuccessors(AState state);
    }
}
