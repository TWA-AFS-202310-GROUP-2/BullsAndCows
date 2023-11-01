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

        [Theory]
        [InlineData("1256")]
        [InlineData("1674")]
        [InlineData("1298")]
        [InlineData("5634")]
        public void Should_return_2A0B_when_guess_given_position_and_digist_partial_right(string guessNumber)
        {
            //given
            string secret = "1234";
            //mock SecretGenerator
            Mock<SecretGenerator> mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            //when
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);
            string result = game.Guess(guessNumber);
            //then
            Assert.Equal("2A0B", result);
        }

        [Theory]
        [InlineData("4321")]
        public void Should_return_0A4B_when_guess_given_position_and_digist_are_incorrect(string guessNumber)
        {
            //given
            string secret = "1234";
            //mock SecretGenerator
            Mock<SecretGenerator> mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            //when
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);
            string result = game.Guess(guessNumber);
            //then
            Assert.Equal("0A4B", result);
        }

        [Theory]
        [InlineData("1562")]
        public void Should_return_1A1B_when_guess_given_position_and_digist_partial_right(string guessNumber)
        {
            //given
            string secret = "1234";
            //mock SecretGenerator
            Mock<SecretGenerator> mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            //when
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);
            string result = game.Guess(guessNumber);
            //then
            Assert.Equal("1A1B", result);
        }
    }
}
