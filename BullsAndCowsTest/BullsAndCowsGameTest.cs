using BullsAndCows;
using Moq;
using Xunit;

namespace BullsAndCowsTest
{
    public class BullsAndCowsGameTest
    {
        [Fact]
        public void Should_create_BullsAndCowsGame()
        {
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            Assert.NotNull(game);
            Assert.True(game.CanContinue);
        }

        [Fact]
        public void Should_return_4A0B_when_guess_given_4_correctlocation_0_correcnumber()
        {
            string guessNumber = "1234";
            string secret = "1234";
            var mockSecretObject = new Mock<SecretGenerator>();
            mockSecretObject.Setup(generator=>generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretObject.Object);

            string guessResult = game.Guess(guessNumber);

            Assert.Equal("4A0B",guessResult);
        }

        [Fact]
        public void Should_return_2A0B_when_guess_given_2_correctlocation_0_correcnumber()
        {
            string guessNumber = "1256";
            string secret = "1234";
            var mockSecretObject = new Mock<SecretGenerator>();
            mockSecretObject.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretObject.Object);

            string guessResult = game.Guess(guessNumber);

            Assert.Equal("2A0B", guessResult);
        }
    }
}
