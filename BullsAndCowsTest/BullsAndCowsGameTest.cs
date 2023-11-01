using BullsAndCows;
using Moq;
using Xunit;

namespace BullsAndCowsTest
{
    public class BullsAndCowsGameTest
    {
        [Fact]
        public void Should_return_4A0B_when_guess_given_guess_number_and_secret_are_the_same()
        {
            //given
            string guessNumber = "1234";
            string secret = "1234";
            //mock SecretGenerator
            Mock<SecretGenerator> mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            //when
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);
            string result = game.Guess(guessNumber);
            //then
            Assert.Equal("4A0B", result);
        }
    }
}
