using BullsAndCows;
using Moq;
using Xunit;

namespace BullsAndCowsTest
{
    public class BullsAndCowsGameTest
    {
        [Fact]
        public void Should_return_4A0B_when_guess_given_guess_number_and_secret_are_same()
        {
            string guessNumber = "1234";
            string secret = "1234";

            Mock<SecretGenerator> mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);

            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);

            string result = game.Guess(guessNumber);

            Assert.Equal("4A0B", result);

            //var secretGenerator = new SecretGenerator();
            //var game = new BullsAndCowsGame(secretGenerator);
            //Assert.NotNull(game);
            //Assert.True(game.CanContinue);
        }

        [Theory]
        [InlineData("1256")]
        [InlineData("1536")]
        [InlineData("5634")]
        [InlineData("1278")]
        public void Should_return_2A0B_when_guess_given_guess_number_and_secret_are_same(string givenNumber)
        {
            string secret = "1234";

            Mock<SecretGenerator> mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);

            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);

            string result = game.Guess(givenNumber);

            Assert.Equal("2A0B", result);
        }
    }
}
