using BullsAndCows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCowsTest
{
    public class GenerateSecretDouble : SecretGenerator
    {
        private string secretGiven;
        public override string GenerateSecret()
        {
            return "1234";
        }

        public void WhenGenerateSecretThenReturn(string givenSecret)
        {
            secretGiven = givenSecret;
        }
    }
}
