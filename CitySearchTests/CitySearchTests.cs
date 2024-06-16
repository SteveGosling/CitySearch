using CitySearch;
using CitySearch.Interfaces;

namespace CitySearchTests
{
    public class CitySearchTests
    {
        private CitySearch.CityFinder _cityFinder;

        [SetUp]
        public void Setup()
        {
            List<string> cityNames = new List<string>
            {
                "New York", "Los Angeles", "Chicago", "Houston", "Phoenix", "London", "Leeds", 
                "Philadelphia", "San Antonio", "San Diego", "Dallas", "San Jose", "Ban Chang", "Bangalore", "Bangkok", "Bandung", "Bangui"
            };
            _cityFinder = new CitySearch.CityFinder(cityNames);
        }

        [Test]
        public void TestNextLetter_SingleCharacter()
        {
            var result = _cityFinder.Search("N");
            CollectionAssert.AreEquivalent(new List<string> { "e" }, result.NextLetters);
        }

        [Test]
        public void TestNextCities_SingleCharacter()
        {
            var result = _cityFinder.Search("N");
            CollectionAssert.Contains(result.NextCities, "new york");
        }

        [Test]
        public void TestNextLetters_MultipleCharacters()
        {
            var result = _cityFinder.Search("Ban");
            CollectionAssert.AreEquivalent(new List<string> { " ", "g", "d" }, result.NextLetters);
        }

        [Test]
        public void TestNextCities_MultipleCharacters()
        {
            var result = _cityFinder.Search("San");
            CollectionAssert.Contains(result.NextCities, "san antonio");
            CollectionAssert.Contains(result.NextCities, "san diego");
            CollectionAssert.Contains(result.NextCities, "san jose");
        }

        [Test]
        public void TestNoNextLetters()
        {
            var result = _cityFinder.Search("X");
            Assert.IsEmpty(result.NextLetters);
        }

        [Test]
        public void TestNoNextCities()
        {
            var result = _cityFinder.Search("X");
            Assert.IsEmpty(result.NextCities);
        }

        [Test]
        [TestCase('a')]
        [TestCase('A')]
        [TestCase(' ')]
        [TestCase('-')]
        [TestCase('x')]
        public void RegexAllowsValidInput(char keyChar)
        {
            var result = CitySearchHelper.IsAllowedChar(keyChar);

            Assert.IsTrue(result);
        }

        [Test]
        [TestCase('@')]
        [TestCase('!')]
        [TestCase('"')]
        [TestCase('_')]
        [TestCase('#')]
        public void RegexRejectsInvalidInput(char keyChar)
        {
            var result = CitySearchHelper.IsAllowedChar(keyChar);

            Assert.IsFalse(result);
        }
    }
}