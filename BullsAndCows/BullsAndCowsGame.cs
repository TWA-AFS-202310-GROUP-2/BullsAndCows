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
            int a=0, b=0;
            if (guess.Equals(secret))
            {
                return "4A0B";
            }

            for (int i=0;i<guess.Length;i++)
            {
                if (guess[i] == secret[i])
                {
                    a++;
                }
                else if (secret.IndexOf(guess[i])!=-1) 
                {
                    b++;
                }
            }
            return $"{a}A{b}B";
        }
    }
}