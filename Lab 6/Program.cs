using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_6
{
    class Program
    {
        static char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A','E','I','O','U' };
        static void Main(string[] args)
        {
            bool repeat = true;
            while (repeat)
            {
                //inform user of program's purpose
                Console.WriteLine("This program will translate a single word into Pig Latin.");
                //personalize program by using user's name
                string name = GetName("Please enter your name: ");
                {
                    string input = GetWord($"Okay {name}, enter a word to translate into Pig Latin: ");
                    string PigLatin = Translate(input);
                    Console.WriteLine($"Your entry translated into Pig Latin is: {PigLatin}");
                }
                repeat = DoAgain($"Would you like to translate another word? (Y or N): ");
            }
            Console.WriteLine("Goodbye!");
            Console.ReadKey();
        }
        //method for translation of word
        public static string Translate(string input)
        {
            int position = input.IndexOfAny(vowels);

            //if input word has no vowels, it will return original word as it cannot be translated
            if (position < 0)
            {
                Console.WriteLine(input);
                return input;
            }
            else
            {
                //stores letters before the first vowel in a char array, casts char array as a string, and stores the remaining letters as its own string
                char[] letters = input.ToCharArray(0,position);
                string prevowel = new string(letters);
                string postvowel = input.Substring(position);

                //if a word begins with a vowel, add "way"
                if (position == 0)
                {
                    input = string.Concat(input + "way");
                    return input;
                }
                //otherwise, take the consonants before the first vowel, move them behind the first vowel, and add "ay"
                else
                {
                    input = string.Concat(postvowel + prevowel + "ay");
                    return input;
                }
            }
        }
        //method to get user's name
        private static string GetName(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
        //method to verify that user entered only one word & that the word is actually a word
        private static string GetWord(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine().Trim();
            if (input.Contains(" ") || input == "" || input.Contains('0') || input.Contains('1') || input.Contains('2') || input.Contains('3') || input.Contains('4') ||
                input.Contains('5') || input.Contains('6') || input.Contains('6') || input.Contains('7') || input.Contains('8') || input.Contains('9'))
            {
                Console.WriteLine("I'm sorry, the input was either not a word or contained multiple words. Try again.");
                return GetWord(prompt);
            }
            return input;
        }
        //method to run program again - will loop if user does not input Y or N
        private static bool DoAgain(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine().ToLower();
            if (input == "y")
            {
                return true;
            }
            else if (input == "n")
            {
                return false;
            }
            else
            {
                Console.Write("Invalid input. ");
                return DoAgain(prompt);
            }
        }
    }
}
