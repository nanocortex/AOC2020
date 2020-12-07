using System.Collections.Generic;
using System.Linq;

namespace Aoc2020.Puzzle7
{
    public class AnswerCalculator
    {
        private const string MyBag = "shiny gold";

        public int Calculate1(IEnumerable<string> input)
        {
            var rules = input.Select(x => Rule.Parse(x.Trim())).ToList();
            return rules.Count(rule => CanHoldBag(rules, rule));
        }

        public int Calculate2(IEnumerable<string> input)
        {
            var rules = input.Select(x => Rule.Parse(x.Trim())).ToList();
            var shinyGoldRule = GetRuleByBag(rules, MyBag);
            return CountBags(rules, shinyGoldRule);
        }

        private bool CanHoldBag(List<Rule> rules, Rule r)
        {
            if (!r.IncludedBags.Any())
                return false;

            return r.IncludedBags.Select(x => x.Bag).Contains(MyBag) || r.IncludedBags.Any(bag => CanHoldBag(rules, GetRuleByBag(rules, bag.Bag)));
        }

        private int CountBags(List<Rule> rules, Rule r)
        {
            var sum = r.IncludedBags.Select(x => x.Count).Sum();
            foreach (var (bag, count) in r.IncludedBags)
            {
                var subRule = GetRuleByBag(rules, bag);

                if (subRule.IncludedBags.Any())
                    sum += count * CountBags(rules, subRule);
            }

            return sum;
        }

        private Rule GetRuleByBag(IEnumerable<Rule> rules, string bag) => rules.FirstOrDefault(x => x.Bag.ToLower().Trim() == bag.ToLower().Trim());
    }
}