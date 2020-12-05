using Shouldly;
using Xunit;

namespace Aoc2020.Puzzle4.Tests
{
    public class SimplePassportValidatorTests
    {
        private readonly SimplePassportValidator _simplePassportValidator = new();
        
        [Theory]
        [InlineData(@"ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
byr:1937 iyr:2017 cid:147 hgt:183cm", true)]
        [InlineData(@"iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884
hcl:#cfa07d byr:1929", false)]
        [InlineData(@"hcl:#ae17e1 iyr:2013
eyr:2024
ecl:brn pid:760753108 byr:1931
hgt:179cm", true)]
        [InlineData(@"hcl:#cfa07d eyr:2025 pid:166559648
iyr:2011 ecl:brn hgt:59in", false)]
        public void ShouldValidatePasswords(string passport, bool shouldBe)
        {
            _simplePassportValidator.Validate(passport).ShouldBe(shouldBe);
        }
    }
}