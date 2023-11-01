using BullsAndCows;
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
    }
}
