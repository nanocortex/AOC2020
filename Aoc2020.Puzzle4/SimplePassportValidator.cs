using System;
using System.Linq;

namespace Aoc2020.Puzzle4
{
    public class SimplePassportValidator
    {
        public bool Validate(string passport)
        {
            passport = passport.Replace(Environment.NewLine, " ");
            var tokens = passport.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            switch (tokens.Length)
            {
                case 8:
                    return true;
                case <= 6:
                    return false;
                default:
                {
                    var keys = tokens.ToList().Select(x => x.Split(":")[0]).ToList();
                    return !keys.Contains("cid");
                }
            }
        }
        
        
    }
}