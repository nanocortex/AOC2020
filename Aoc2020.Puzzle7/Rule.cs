using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2020.Puzzle7
{
    public class Rule
    {
        private Rule(string bag, List<IncludedBag> includedBags)
        {
            Bag = bag;
            IncludedBags = includedBags;
        }

        public string Bag { get; set; }

        public List<IncludedBag> IncludedBags { get; set; }

        public static Rule Parse(string s)
        {
            var tokens = s.Split(" ");
            var bag = $"{tokens[0]} {tokens[1]}".Trim();
            var includedBags = new List<IncludedBag>();

            var includedPart = string.Join(" ", tokens.Skip(4).ToArray());

            if (includedPart.Trim() == "no other bags.")
                return new Rule(bag, includedBags);

            var includedBagParts = includedPart.Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in includedBagParts)
            {
                var includedBagTokens = part.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var b = $"{includedBagTokens[1]} {includedBagTokens[2]}";
                var includedBag = new IncludedBag(b, int.Parse(includedBagTokens[0]));
                includedBags.Add(includedBag);
            }

            return new Rule(bag, includedBags);
        }

        public override string ToString()
        {
            return $"{Bag} contains {string.Join(", ", IncludedBags.Select(x => $"{x.Count} {x.Bag}").ToArray())}";
        }
    }
}