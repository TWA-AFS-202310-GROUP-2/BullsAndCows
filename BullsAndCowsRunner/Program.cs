using System;
using BullsAndCows;

namespace BullsAndCowsRunner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SecretGenerator secretGenerator = new SecretGenerator();
            BullsAndCowsGame game = new BullsAndCowsGame(secretGenerator);
            Console.WriteLine("Welcome to Bulls and Cows! Try to guess the 4-digit secret number.");

            int attemps = 1;
            while (game.CanContinue)
            {
                Console.Write("Enter your guess: ");
                var input = Console.ReadLine();
                var output = game.Guess(input);
                Console.WriteLine(output);

                if (output == "4A0B")
                {
                    Console.WriteLine("Congratulations! You've guessed the secret number");
                    break;
                }
                else if (attemps > 6)
                {
                    break;
                }

                attemps++;
            }

            Console.WriteLine("Game Over");
        }
    }
}