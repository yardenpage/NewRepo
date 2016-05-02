using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.Search
{
    public interface ISearchable
    {
        AState GetStartState();
        AState GetGoalState();
        IEnumerable<AState> GetAllSuccessors(AState state);
    }
}
