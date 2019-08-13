using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGuess
{
    class Program
    {
        const int MaximumIncorrectGuesses = 10;
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
            HashSet<char> phraseDistinctCharacters = GetPhraseDistinctCharacters(phraseCharacters);

            bool gameWin = false;
            var phraseGuessedCharacters = new List<char>();
            int incorrectGuesses = 0;
            
            do
            {
                Console.WriteLine();
                Console.WriteLine("You have {0} guesses remaining.", MaximumIncorrectGuesses - incorrectGuesses);
                DisplayPhrase(phraseCharacters, phraseGuessedCharacters);
                char guessedCharacter = GetCharacterGuess(phraseGuessedCharacters);
                if (phraseDistinctCharacters.Contains(guessedCharacter))
                {
                    Console.WriteLine();
                    Console.WriteLine("Correct! {0} is in the phrase.", guessedCharacter);
                    if (phraseGuessedCharacters.Count == phraseDistinctCharacters.Count)
                    {
                        gameWin = true;
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Sorry, {0} is not in the phrase.", guessedCharacter);
                    incorrectGuesses++;
                }
            }
            while (!gameWin && incorrectGuesses < MaximumIncorrectGuesses);

            if (!gameWin)
            {
                Console.WriteLine();
                Console.WriteLine("You're out of guesses. Better luck next time! The phrase is:");
                Console.WriteLine(phrase.ToUpper());
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Well done! The phrase is: ");
                Console.WriteLine(phrase.ToUpper());
            }
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
            distinctCharacters.RemoveWhere(IsNotLetter);
            return distinctCharacters;
        }

        /// <summary>
        /// Predicate method that checks whether or not a character is a letter.
        /// </summary>
        /// <param name="character">The character to check.</param>
        /// <returns>True if not a letter; false if a letter.</returns>
        static bool IsNotLetter(char character)
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

        /// <summary>
        /// Prints each character to the console depending on whether or not the player has guessed it.
        /// </summary>
        /// <param name="phraseCharacters">The array of characters of the phrase.</param>
        /// <param name="phraseGuessedCharacters">The list of guessed characters.</param>
        static void DisplayPhrase(char[] phraseCharacters, List<char> phraseGuessedCharacters)
        {
            foreach (char character in phraseCharacters)
            {
                if (phraseGuessedCharacters.Contains(character) || IsNotLetter(character))
                {
                    Console.Write(character);
                }
                else
                {
                    Console.Write("#");
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Prompts the player to input a character and returns the character if it has not yet been guessed.
        /// </summary>
        /// <param name="guessedCharacters">The list of characters already guessed.</param>
        /// <returns>The new character.</returns>
        static char GetCharacterGuess(List<char> guessedCharacters)
        {
            bool newCharacter = false;
            bool validCharacter = false;
            char guess;
            do
            {
                do
                {
                    Console.WriteLine();
                    Console.Write("Please enter a letter: ");
                    guess = Console.ReadKey().KeyChar;
                    if (IsNotLetter(guess))
                    {
                        Console.WriteLine();
                    }
                    else
                    {
                        validCharacter = true;
                    }
                }
                while (!validCharacter);

                guess = char.ToUpper(guess);
                if (guessedCharacters.Contains(guess))
                {
                    Console.WriteLine();
                    Console.Write("You have already guessed that character. ");
                }
                else
                {
                    guessedCharacters.Add(guess);
                    newCharacter = true;
                }
            }
            while (!newCharacter);

            return guess;
            
        }
    }
}
