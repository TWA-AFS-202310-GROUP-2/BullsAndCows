using System;
using System.Collections.Generic;

namespace BullsAndCows
{
    public class SecretGenerator
    {
        private static Random random = new Random();

        public virtual string GenerateSecret()
        {
            var digits = new HashSet<int>();
            while (digits.Count < 4)
            {
                int digit = random.Next(0, 10);
                digits.Add(digit);
            }

            return string.Join(" ", digits);
        }
    }
}
