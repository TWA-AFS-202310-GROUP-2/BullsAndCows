using System;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private readonly string secret;
        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            this.secret = secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

        public string Guess(string guess)
        {
            if (this.secret == guess)
            {
                return "4A0B";
            }

            int bulls = 0;
            for (int i = 0; i < secret.Length; i++)
            {
                if (guess.IndexOf(secret[i]) == i)
                {
                    bulls++;
                }
            }

            return $"{bulls}A0B";
        }

        
    }
}