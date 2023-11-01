using System;
using System.Linq;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private string secret;

        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            this.secret = secretGenerator.GenerateSecret();
        }

        public bool CanContinue { get; set; } = true;

        public string Guess(string guess)
        {
            if (guess.Length != 4 || !guess.All(char.IsDigit) || guess.Distinct().Count() != 4)
            {
                return "Wrong Input, input again";
            }

            int bulls = 0;
            int cows = 0;

            for (int i = 0; i < 4; i++)
            {
                if (guess[i] == secret[i])
                {
                    bulls++;
                }
                else if (secret.Contains(guess[i]))
                {
                    cows++;
                }
            }

            if (bulls == 4)
            {
                this.End();
            }

            return $"{bulls}A{cows}B";
        }

        public void End()
        {
            this.CanContinue = false;
        }
    }
}
