using Shouldly;
using Xunit;

namespace Aoc2020.Puzzle2.Tests
{
    public class PasswordValidatorTests
    {
        private readonly PasswordValidator _passwordValidator = new();

        [Theory]
        [InlineData("1-3 a: abcde", true)]
        [InlineData("1-3 b: cdefg", false)]
        [InlineData("2-9 c: ccccccccc", true)]
        public void ShouldValidatePasswordByPolicy1(string policyAndPassword, bool valid)
        {
            _passwordValidator.Validate1(policyAndPassword).ShouldBe(valid);
        }

        [Theory]
        [InlineData("1-3 a: abcde", true)]
        [InlineData("1-3 b: cdefg", false)]
        [InlineData("2-9 c: ccccccccc", false)]
        [InlineData("3-4 d: ccccccccc", false)]
        [InlineData("1-2 x: xcccccccc", true)]
        public void ShouldValidatePasswordByPolicy2(string policyAndPassword, bool valid)
        {
            _passwordValidator.Validate2(policyAndPassword).ShouldBe(valid);
        }
    }
}