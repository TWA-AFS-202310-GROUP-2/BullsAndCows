using System;
using System.Collections.Generic;

namespace BullsAndCows
{
    public class SecretGenerator
    {
        public virtual string GenerateSecret()
        {
            var random = new Random();
            var digits = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string secret = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                int index = random.Next(0, digits.Count);
                secret += digits[index];
                digits.Remove(index);
            }

            return secret;
        }
    }
}