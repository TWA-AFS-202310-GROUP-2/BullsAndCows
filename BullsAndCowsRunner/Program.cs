using System;
using BullsAndCows;

namespace BullsAndCowsRunner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SecretGenerator secretGenerator = new SecretGenerator();
            RunGame(secretGenerator);
        }

        public static void RunGame(SecretGenerator secretGenerator)
        {
            BullsAndCowsGame game = new BullsAndCowsGame(secretGenerator);

            int maxGuesses = 6;
            int currentGuesses = 0;

            while (game.CanContinue && currentGuesses < maxGuesses)
            {
                var input = Console.ReadLine();
                var output = game.Guess(input);

                Console.WriteLine(output);

                if (output == "4A0B")
                {
                    Console.WriteLine("Congratulations! You guessed the number.");
                    return;
                }

                currentGuesses++;
            }

            Console.WriteLine("Game Over");
        }
    }
}
