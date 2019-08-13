using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGuess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Word Guess app!");
            List<string> phrases = GetPhrases();
            PlayGame(phrases);
            Console.ReadKey();
        }

        /// <summary>
        /// Returns a list of phrases (strings) to be used in the game.
        /// </summary>
        /// <returns>The list of strings.</returns>
        static List<string> GetPhrases()
        {
            var phrases = new List<string>();
            phrases.Add("To be or not to be, that is the question");
            phrases.Add("All the world's a stage");
            phrases.Add("Parting is such sweet sorrow");
            phrases.Add("To thine own self be true");
            return phrases;
        }

        /// <summary>
        /// Selects and returns a random phrase from a list of phrases.
        /// </summary>
        /// <param name="phrases">The list of phrases.</param>
        /// <returns>A random phrase from the list.</returns>
        static string SelectPhrase(List<string> phrases)
        {
            var randomizer = new Random();
            var randomIndex = randomizer.Next(0, phrases.Count);
            return phrases[randomIndex];
        }

        /// <summary>
        /// This is the method where the game is played.
        /// </summary>
        /// <param name="phrases">The list of phrases to choose from.</param>
        static void PlayGame(List<string> phrases)
        {
            string phrase = SelectPhrase(phrases);
            char[] phraseCharacters = GetPhraseCharacters(phrase);
            HashSet<char> distinctCharacters = GetPhraseDistinctCharacters(phraseCharacters);

        }

        /// <summary>
        /// Returns an array of uppercase characters from the input string.
        /// </summary>
        /// <param name="phrase">The phrase to extract characters from.</param>
        /// <returns>The array of uppercase characters.</returns>
        static char[] GetPhraseCharacters(string phrase)
        {
            char[] phraseCharacters = phrase.ToUpper().ToCharArray();
            return phraseCharacters;
        }

        /// <summary>
        /// Returns a HashSet of distinct letters from an input character array.
        /// </summary>
        /// <param name="phraseCharacters">The character array to prune.</param>
        /// <returns>A HashSet of distinct characters.</returns>
        static HashSet<char> GetPhraseDistinctCharacters(char[] phraseCharacters)
        {
            var distinctCharacters = new HashSet<char>(phraseCharacters);
            distinctCharacters.RemoveWhere(NotLetter);
            return distinctCharacters;
        }

        /// <summary>
        /// Predicate method that checks whether or not a character is a letter.
        /// </summary>
        /// <param name="character">The character to check.</param>
        /// <returns>True if not a letter; false if a letter.</returns>
        static bool NotLetter(char character)
        {
            if (!char.IsLetter(character))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
