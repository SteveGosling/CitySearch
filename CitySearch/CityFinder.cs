using CitySearch.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySearch
{
    public class CityFinder : ICityFinder
    {
        private SearchTree _tree;

        public CityFinder(List<string> cityNames)
        {
            _tree = new SearchTree();
            foreach (var city in cityNames)
            {
                _tree.Insert(city.ToLower());
            }
        }

        public ICityResult Search(string searchString)
        {
            var result = new CityResult();
            var lowerSearchString = searchString.ToLower();

            // get suggested next characters based on previous input
            result.NextLetters = _tree.SuggestNextCharacters(lowerSearchString);

            // get suggested city names based on previous input
            result.NextCities = _tree.SuggestNextCities(lowerSearchString);

            return result;
        }
    }
}
