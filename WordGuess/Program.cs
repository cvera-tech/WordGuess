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

    }
}
