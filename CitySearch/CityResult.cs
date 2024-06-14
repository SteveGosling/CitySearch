using CitySearch.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySearch
{
    public class CityResult : ICityResult
    {
        public ICollection<string> NextLetters { get; set; }

        public ICollection<string> NextCities { get; set; }

        public CityResult()
        {
            NextLetters = new List<string>();
            NextCities = new List<string>();
        }
    }
}
