using System;
using System.Collections.Generic;
using System.Linq;
using TestProject.Data;
using TestProject.Workers;

namespace TestProject
{
    class Program
    {
        private const string wordListFileName = "wordlist.txt";
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();


        static void Main(string[] args)
        {
            bool continueWordUnscramble = true;
            do
            {
                Console.WriteLine("Enter option F for file M for manual");
                var option = Console.ReadLine() ?? string.Empty;

                switch (option.ToUpper())
                {
                    case "F":
                        Console.Write("Enter scrabled words file name");
                        ExecuteFileScrabledWords();
                        break;
                    case "M":
                        Console.Write("Enter scrabled words manually");
                        ExecuteManualScrabledWords();
                        break;
                    default:
                        Console.Write("Option not recognized");
                        break;
                }
                var continueDecision = string.Empty;
                do
                {
                    Console.WriteLine("Do you want to continue? Y/N");
                    continueDecision = (Console.ReadLine() ?? string.Empty);
                } while (
                    !continueDecision.Equals("Y", StringComparison.OrdinalIgnoreCase) && 
                    !continueDecision.Equals("N", StringComparison.OrdinalIgnoreCase));

                continueWordUnscramble = continueDecision.Equals("Y", StringComparison.OrdinalIgnoreCase);
            } while (continueWordUnscramble);
        }

        private static void ExecuteManualScrabledWords()
        {
            var manualInput = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = manualInput.Split(',');
            DisplayMatched(scrambledWords);
        }       

        private static void ExecuteFileScrabledWords()
        {
            var filename = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = _fileReader.Read(filename);
            DisplayMatched(scrambledWords);
        }

        private static void DisplayMatched(string[] scrambledWords)
        {
            string[] wordList = _fileReader.Read(wordListFileName);

            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords,wordList);

            if (matchedWords.Any())
            {
                foreach (var matchedWord in matchedWords)
                {
                    Console.WriteLine("Match found for {0}: {1}",matchedWord.ScrambledWord, matchedWord.Word);
                }
            }
            else
            {
                Console.WriteLine("No matches have been found");
            }
        }
    }
}
