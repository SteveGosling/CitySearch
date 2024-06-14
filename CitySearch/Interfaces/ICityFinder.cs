using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySearch.Interfaces
{
    public interface ICityFinder
    {
        /// <summary>
        /// Call the Search function with the users input
        /// </summary>
        /// <param name="searchString">The string value to lookup</param>
        /// <returns></returns>
        ICityResult Search(string searchString);
    }
}
