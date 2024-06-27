using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CitySearch
{
    public class TreeNode
    {
        public char Value { get; set; }
        public Dictionary<char, TreeNode> Children { get; set; }
        public bool IsEndOfWord { get; set; }

        public TreeNode(char value)
        {
            Value = value; 
            Children = new Dictionary<char, TreeNode>();
            IsEndOfWord = false;
        }
    }

    public class SearchTree
    {
        private TreeNode root;

        public SearchTree()
        {
            root = new TreeNode(' ');
        }

        public void Insert(string word)
        {
            var currentNode = root;
            
            foreach (var character in word)
            {
                if (!currentNode.Children.ContainsKey(character))
                    currentNode.Children[character] = new TreeNode(character);
            
                currentNode = currentNode.Children[character];
            }

            currentNode.IsEndOfWord = true;
        }

        /// <summary>
        /// Check for and return the next available characters from the list of cities
        /// </summary>
        /// <param name="prefix">The current string entered so far</param>
        /// <returns>A list of next characters based on the current input</returns>
        public List<string> SuggestNextCharacters(string prefix)
        {
            var currentNode = root;

            // get the last character to save looping through the entire string
            var character = prefix.Last();
            
            if (!currentNode.Children.ContainsKey(character))
                return new List<string>();

            currentNode = currentNode.Children[character];
            
            return new List<string>(currentNode.Children.Keys.Select(x => x.ToString()));
        }

        /// <summary>
        /// Check for an return the available cities based on the string value
        /// </summary>
        /// <param name="prefix">The current string entered so far</param>
        /// <returns>A list of city names that match the current input</returns>
        public List<string> SuggestNextCities(string prefix)
        {
            var currentNode = root;
            
            foreach (var character in prefix)
            {
                if (!currentNode.Children.ContainsKey(character))
                    return new List<string>();

                currentNode = currentNode.Children[character];
            }

            return GatherAllWords(currentNode, prefix);
        }

        private List<string> GatherAllWords(TreeNode node, string currentPrefix)
        {
            List<string> words = new List<string>();

            if (node.IsEndOfWord)
                words.Add(currentPrefix);

            foreach (var child in node.Children.Values)
            {
                words.AddRange(GatherAllWords(child, currentPrefix + child.Value));
            }

            return words;
        }
    }
}
