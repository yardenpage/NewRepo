using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.Search
{
    /// <summary>
    /// an interface of ISearchingAlgorithm
    /// </summary>
    public interface ISearchingAlgorithm
    {

        Solution Solve(ISearchable searchDomain);

        int GetNumberOfGeneratedNodes();

        double GetSolvingTimeMiliseconds();
    }
}
