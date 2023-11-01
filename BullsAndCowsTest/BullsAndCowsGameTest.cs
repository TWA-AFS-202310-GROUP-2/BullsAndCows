using BullsAndCows;
using Moq;
using Xunit;

namespace BullsAndCowsTest
{
    public class BullsAndCowsGameTest
    {
        //[Fact]
        //public void Should_create_BullsAndCowsGame()
        //{
        //    var secretGenerator = new SecretGenerator();
        //    var game = new BullsAndCowsGame(secretGenerator);
        //    Assert.NotNull(game);
        //    Assert.True(game.CanContinue);
        //}

        // case 1: 4A0B
        [Fact]
        public void Should_return_4A0B_when_Guess_given_four_digits_correct_right_loc()
        {
            // Given
            string guessNumber = "1234";
            string secret = "1234";
            //var secretGenerator = new SecretGenerator();
            //var secretGenerator = new GenerateSecretDouble();
            //secretGenerator.WhenGenerateSecretThenReturn(secret);

            Mock<SecretGenerator> mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);

            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);
            // When
            string result = game.Guess(guessNumber);
            // Then
            Assert.Equal("4A0B", result);
        }

        // case 2: 2A0B
        [Theory]
        [InlineData("1256")]
        [InlineData("5634")]
        [InlineData("5236")]
        [InlineData("1564")]
        public void Should_return_2A0B_when_Guess_given_partial_digits_correct_right_loc(string guessNumber)
        {
            // Given
            string secret = "1234";

            Mock<SecretGenerator> mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);

            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);
            // When
            string result = game.Guess(guessNumber);
            // Then
            Assert.Equal("2A0B", result);
        }

        // case 3: 1A1B
        [Theory]
        [InlineData("1562")]
        public void Should_return_1A1B_when_Guess_given_partial_digits_correct_partial_correct_loc(string guessNumber)
        {
            // Given
            string secret = "1234";

            Mock<SecretGenerator> mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);

            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);
            // When
            string result = game.Guess(guessNumber);
            // Then
            Assert.Equal("1A1B", result);
        }

        // case 4: 0A0B
        [Theory]
        [InlineData("5678")]
        public void Should_return_0A0B_when_Guess_given_wrong_digits_wrong_loc(string guessNumber)
        {
            // Given
            string secret = "1234";

            Mock<SecretGenerator> mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);

            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);
            // When
            string result = game.Guess(guessNumber);
            // Then
            Assert.Equal("0A0B", result);
        }
    }
}
