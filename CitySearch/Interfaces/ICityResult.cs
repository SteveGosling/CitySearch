using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySearch.Interfaces
{
    public interface ICityResult
    {
        /// <summary>
        /// Collection to store the next available letters based on previous input
        /// </summary>
        ICollection<string> NextLetters { get; set; }

        /// <summary>
        /// Collection to store the possible city name based on previous input
        /// </summary>
        ICollection<string> NextCities { get; set; }
    }
}
