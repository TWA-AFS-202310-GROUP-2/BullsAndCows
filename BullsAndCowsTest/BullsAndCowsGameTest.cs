using BullsAndCows;
using Moq;
using System.IO;
using System;
using Xunit;
using BullsAndCowsRunner;

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

        [Fact]
        public void Should_end_game_after_6_guesses()
        {
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(ms => ms.GenerateSecret()).Returns("1234");

            // Simulate user input
            //string userInput = "1243\n5678\n9101\n2345\n6789\n3456\n";
            string userInput = "1243\n";
            StringReader stringReader = new StringReader(userInput);
            Console.SetIn(stringReader);

            // Capture console output
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Run the runGame method
            Program.Run(mockSecretGenerator.Object);

            // Capture the output and reset the console
            string output = stringWriter.ToString();
            Console.SetIn(Console.In);
            Console.SetOut(Console.Out);

            // Assert that the game ends after 6 guesses
            Assert.Contains("Game Over", output);
        }

        [Theory]
        [InlineData("2399", "Invalid input. Please enter a 4-digit number.")] // 重复数字
        [InlineData("b90d", "Invalid input. Please enter a 4-digit number.")] // 非数字
        [InlineData("123", "Invalid input. Please enter a 4-digit number.")] // 少于4位
        public void Should_return_error_message_when_guess_given_invalid_input(string input, string expected)
        {
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            var result = game.Guess(input);
            Assert.Equal(expected, result);
        }
    }
}
