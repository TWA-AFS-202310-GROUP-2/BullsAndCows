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
        public void Should_return_4A0B_when_guess_give_number_and_secret_are_same()
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

        [Theory]
        [InlineData("1287")]
        [InlineData("5634")]
        [InlineData("7254")]
        [InlineData("1604")]
        public void Should_return_2A0B_when_guess_given_partial_position_and_number_are_right(string guessNumber)
        {
            //given
            //string guessNumber = "1287";

            //when
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(ms => ms.GenerateSecret()).Returns("1234");
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            var res = game.Guess(guessNumber);

            //then
            Assert.Equal("2A0B", res);
        }

        [Theory]
        [InlineData("5678")]
        [InlineData("8976")]
        public void Should_return_0A0B_when_guess_given_no_position_and_no_number_are_right(string guessNumber)
        {
            //given
            //string guessNumber = "1287";

            //when
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(ms => ms.GenerateSecret()).Returns("1234");
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            var res = game.Guess(guessNumber);

            //then
            Assert.Equal("0A0B", res);
        }

        [Theory]
        [InlineData("1562")]
        [InlineData("1527")]
        public void Should_return_1A1B_when_guess_given_some_position_and_some_number_are_right(string guessNumber)
        {
            //given
            //string guessNumber = "1287";

            //when
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(ms => ms.GenerateSecret()).Returns("1234");
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            var res = game.Guess(guessNumber);

            //then
            Assert.Equal("1A1B", res);
        }

        [Theory]
        [InlineData("4321")]
        public void Should_return_0A4B_when_guess_given_no_position_but_all_number_are_right(string guessNumber)
        {
            //given
            //string guessNumber = "1287";

            //when
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(ms => ms.GenerateSecret()).Returns("1234");
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            var res = game.Guess(guessNumber);

            //then
            Assert.Equal("0A4B", res);
        }

        [Theory]
        [InlineData("1243")]
        public void Should_return_2A2B_when_guess_given_some_position_and_some_number_are_right(string guessNumber)
        {
            //given
            //string guessNumber = "1287";

            //when
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(ms => ms.GenerateSecret()).Returns("1234");
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            var res = game.Guess(guessNumber);

            //then
            Assert.Equal("2A2B", res);
        }

        [Theory]
        [InlineData("1256")]
        public void Should_return_0A2B_when_guess_given_some_position_and_no_number_are_right(string guessNumber)
        {
            //given
            //string guessNumber = "1287";

            //when
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(ms => ms.GenerateSecret()).Returns("1234");
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            var res = game.Guess(guessNumber);

            //then
            Assert.Equal("2A0B", res);
        }
    }
}
