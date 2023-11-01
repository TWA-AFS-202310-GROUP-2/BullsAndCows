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

        [Theory]
        [InlineData("1234")]
        public void Should_return_4A0B_when_guess_given_4_correctlocation_0_correcnumber(string guessNumber)
        {
            string secret = "1234";
            var mockSecretObject = new Mock<SecretGenerator>();
            mockSecretObject.Setup(generator=>generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretObject.Object);

            string guessResult = game.Guess(guessNumber);

            Assert.Equal("4A0B",guessResult);
        }

        [Theory]
        [InlineData("5678")]
        public void Should_return_0A0B_when_guess_given_0_correctlocation_0_correcnumber(string guessNumber)
        {
            string secret = "1234";
            var mockSecretObject = new Mock<SecretGenerator>();
            mockSecretObject.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretObject.Object);

            string guessResult = game.Guess(guessNumber);

            Assert.Equal("0A0B", guessResult);
        }

        [Theory]
        [InlineData("1256")]
        public void Should_return_2A0B_when_guess_given_2_correctlocation_0_correcnumber(string guessNumber)
        {
            string secret = "1234";
            var mockSecretObject = new Mock<SecretGenerator>();
            mockSecretObject.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretObject.Object);

            string guessResult = game.Guess(guessNumber);

            Assert.Equal("2A0B", guessResult);
        }

        [Theory]
        [InlineData("1324")]
        public void Should_return_2A2B_when_guess_given_2_correctlocation_2_correcnumber(string guessNumber)
        {
            string secret = "1234";
            var mockSecretObject = new Mock<SecretGenerator>();
            mockSecretObject.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretObject.Object);

            string guessResult = game.Guess(guessNumber);

            Assert.Equal("2A2B", guessResult);
        }

        [Theory]
        [InlineData("1562")]
        public void Should_return_1A1B_when_guess_given_1_correctlocation_1_correcnumber(string guessNumber)
        {
            string secret = "1234";
            var mockSecretObject = new Mock<SecretGenerator>();
            mockSecretObject.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretObject.Object);

            string guessResult = game.Guess(guessNumber);

            Assert.Equal("1A1B", guessResult);
        }
    }
}
