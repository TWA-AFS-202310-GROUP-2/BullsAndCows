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
        public void Should_return_4A0B_when_guess_number_and_secret_are_same()
        {
            //given
            string guessNumber = "1234";

            //when
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(ms => ms.GenerateSecret()).Returns("1234");
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            var res = game.Guess(guessNumber);

            //then
            Assert.Equal("4A0B", res);
        }
    }
}
