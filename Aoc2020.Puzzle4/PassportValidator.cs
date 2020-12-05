using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Aoc2020.Puzzle4
{
    public class PassportValidator
    {
        private readonly string[] _requiredKeys = {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};

        public bool Validate(string passport)
        {
            passport = passport.Replace(Environment.NewLine, " ").Trim();

            var dict = passport.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(part => part.Split(':'))
                .ToDictionary(split => split[0], split => split[1]);

            if (dict.Count <= 6)
                return false;

            if (!_requiredKeys.All(x => dict.Any(y => y.Key == x)))
                return false;

            if (!ValidateBirthYear(dict["byr"]))
                return false;

            if (!ValidateIssueYear(dict["iyr"]))
                return false;

            if (!ValidateExpirationYear(dict["eyr"]))
                return false;

            if (!ValidateHeight(dict["hgt"]))
                return false;

            if (!ValidateHairColor(dict["hcl"]))
                return false;

            if (!ValidateEyeColor(dict["ecl"]))
                return false;

            if (!ValidatePassportId(dict["pid"]))
                return false;

            return true;
        }

        private bool ValidateBirthYear(string byr) => ValidateYear(byr, 1920, 2002);

        private bool ValidateIssueYear(string iyr) => ValidateYear(iyr, 2010, 2020);

        private bool ValidateExpirationYear(string eyr) => ValidateYear(eyr, 2020, 2030);

        private bool ValidateYear(string s, int minYear, int maxYear)
        {
            if (s.Length != 4)
                return false;

            var year = int.Parse(s);
            return year >= minYear && year <= maxYear;
        }

        private bool ValidateHeight(string height)
        {
            if (!height.EndsWith("cm") && !height.EndsWith("in"))
                return false;

            var number = int.Parse(height.Substring(0, height.Length - 2));

            if (height.EndsWith("cm"))
                return number >= 150 && number <= 193;

            return number >= 59 && number <= 76;
        }

        private bool ValidateHairColor(string hairColor)
        {
            if (hairColor.Length != 7)
                return false;

            var regex = new Regex("^#[a-fA-F0-9]{6}$");
            return regex.IsMatch(hairColor);
        }

        private bool ValidateEyeColor(string hairColor) => new[] {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"}.Contains(hairColor);

        private bool ValidatePassportId(string passportId) => passportId.Length == 9 && long.TryParse(passportId, out _);
    }
}