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
        /// <summary>
        /// solve the problem
        /// </summary>
        /// <param name="searchDomain"></param>
        /// <returns>a solution to the problem</returns>
        Solution Solve(ISearchable searchDomain);
        /// <summary>
        /// get the number of generated nodes
        /// </summary>
        /// <returns>number of nodes</returns>
        int GetNumberOfGeneratedNodes();
        /// <summary>
        /// calculate the time of the solving in miliseconds
        /// </summary>
        /// <returns>the time</returns>
        double GetSolvingTimeMiliseconds();
    }
}
