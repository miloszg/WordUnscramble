using System;

namespace TestProject
{
    class Program
    {
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
                var continueWordUnscrambleDecision = string.Empty;
                do
                {
                    Console.WriteLine("Do you want to continue? Y/N");
                    continueWordUnscrambleDecision = (Console.ReadLine() ?? string.Empty);
                } while (!continueWordUnscrambleDecision.Equals("Y", StringComparison.OrdinalIgnoreCase) && !continueWordUnscrambleDecision.Equals("N", StringComparison.OrdinalIgnoreCase));
                continueWordUnscramble = continueWordUnscrambleDecision.Equals("Y", StringComparison.OrdinalIgnoreCase);
            } while (continueWordUnscramble);
        }

        private static void ExecuteManualScrabledWords()
        {
            
        }

        private static void ExecuteFileScrabledWords()
        {
            
        }
    }
}
