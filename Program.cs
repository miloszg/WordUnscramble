using System;
using System.Collections.Generic;
using System.Linq;
using TestProject.Data;
using TestProject.Workers;

namespace TestProject
{
    class Program
    {
        
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();


        static void Main(string[] args)
        {
            try
            {
                bool continueWordUnscramble = true;
                do
                {
                    Console.WriteLine(Constants.HowToEnterScrambledWords);
                    var option = Console.ReadLine() ?? string.Empty;

                    switch (option.ToUpper())
                    {
                        case Constants.File:
                            Console.Write(Constants.EnterScrambledWordFile);
                            ExecuteFileScrabledWords();
                            break;
                        case Constants.Manual:
                            Console.Write(Constants.EnterScrambledWordManual);
                            ExecuteManualScrabledWords();
                            break;
                        default:
                            Console.Write(Constants.OptionNotRecognized);
                            break;
                    }
                    var continueDecision = string.Empty;
                    do
                    {
                        Console.WriteLine(Constants.ContinueOption);
                        continueDecision = (Console.ReadLine() ?? string.Empty);
                    } while (
                        !continueDecision.Equals(Constants.Confirm, StringComparison.OrdinalIgnoreCase) &&
                        !continueDecision.Equals(Constants.Decline, StringComparison.OrdinalIgnoreCase));

                    continueWordUnscramble = continueDecision.Equals(Constants.Confirm, StringComparison.OrdinalIgnoreCase);
                } while (continueWordUnscramble);
            } catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorProgramTerminated + ex.Message);
            }
        }

        private static void ExecuteManualScrabledWords()
        {
            try
            {
                var manualInput = Console.ReadLine() ?? string.Empty;
                string[] scrambledWords = manualInput.Split(',');
                DisplayMatched(scrambledWords);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(Constants.ErrorScrambledWordsCannotBeLoaded);
                Console.WriteLine("Kupa");
            }
            
        }       

        private static void ExecuteFileScrabledWords()
        {
            try
            {
                var filename = Console.ReadLine() ?? string.Empty;
                string[] scrambledWords = _fileReader.Read(filename);
                DisplayMatched(scrambledWords);
            } catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorScrambledWordsCannotBeLoaded);
            }
        }

        private static void DisplayMatched(string[] scrambledWords)
        {
            string[] wordList = _fileReader.Read(Constants.wordListFileName);

            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords,wordList);

            if (matchedWords.Any())
            {
                foreach (var matchedWord in matchedWords)
                {
                    Console.WriteLine(Constants.MatchFound,matchedWord.ScrambledWord, matchedWord.Word);
                }
            }
            else
            {
                Console.WriteLine(Constants.MatchNotFound);
            }
        }
    }
}
