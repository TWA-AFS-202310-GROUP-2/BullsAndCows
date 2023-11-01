using System;
using System.IO;
using System.Linq;
using BullsAndCows;
using BullsAndCowsRunner;
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
        [InlineData("1123", "Wrong Input, input again")] // 重复数字
        [InlineData("abcd", "Wrong Input, input again")] // 非数字
        [InlineData("123", "Wrong Input, input again")] // 少于4位
        public void Should_return_error_message_for_invalid_input(string input, string expected)
        {
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            var result = game.Guess(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1234", "4A0B")] // 4A0B
        [InlineData("1238", "3A0B")] // 3A0B
        [InlineData("1243", "2A2B")] // 2A2B
        [InlineData("1248", "2A1B")] // 2A1B
        [InlineData("1256", "2A0B")] // 2A0B
        [InlineData("1423", "1A3B")] // 1A3B
        [InlineData("1325", "1A2B")] // 1A2B
        [InlineData("1673", "1A1B")] // 1A1B
        [InlineData("1789", "1A0B")] // 1A0B
        [InlineData("2143", "0A4B")] // 0A4B
        [InlineData("2146", "0A3B")] // 0A3B
        [InlineData("2563", "0A2B")] // 0A2B
        [InlineData("2789", "0A1B")] // 0A1B
        [InlineData("5678", "0A0B")] // 0A0B
        public void Should_return_correct_number_of_bulls_and_cows(string guess, string expected)
        {
            var mockSecretGenerator = new MockSecretGenerator();
            var game = new BullsAndCowsGame(mockSecretGenerator);
            var result = game.Guess(guess);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Should_end_game_after_correct_guess()
        {
            var mockSecretGenerator = new MockSecretGenerator();
            var game = new BullsAndCowsGame(mockSecretGenerator);
            var result = game.Guess("1234");
            Assert.Equal("4A0B", result);
            Assert.False(game.CanContinue);
        }

        [Fact]
        public void Should_return_4_digits_without_duplicate()
        {
            var secretGenerator = new SecretGenerator();
            var secret = secretGenerator.GenerateSecret();
            Assert.Equal(4, secret.Split(" ").Distinct().Count());
        }

        [Fact]
        public void Should_Run_Main_And_End_Game_After_6_Guesses()
        {
            var mockSecretGenerator = new MockSecretGenerator();
            // Simulate user input
            string userInput = "1243\n5678\n9101\n2345\n6789\n3456\n";
            StringReader stringReader = new StringReader(userInput);
            Console.SetIn(stringReader);

            // Capture console output
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Run the runGame method
            Program.RunGame(mockSecretGenerator);

            // Capture the output and reset the console
            string output = stringWriter.ToString();
            Console.SetIn(Console.In);
            Console.SetOut(Console.Out);

            // Assert that the game ends after 6 guesses
            Assert.Contains("Game Over", output);
        }
    }

    public class MockSecretGenerator : SecretGenerator
    {
        public override string GenerateSecret()
        {
            return "1234";
        }
    }
}
