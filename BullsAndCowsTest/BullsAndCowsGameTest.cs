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
    }
}
