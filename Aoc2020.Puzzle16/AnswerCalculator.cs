using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2020.Puzzle16
{
    public class AnswerCalculator
    {
        public int Calculate1(string input)
        {
            var rules = ParseRules(input);
            var nearbyTickets = ParseNearbyTickets(input).ToList();
            return nearbyTickets.Sum(ticket => SumInvalidTicketFields(ticket, rules));
        }

        public long Calculate2(string input)
        {
            var rulesBase = ParseRules(input);
            var myTicket = ParseMyTicket(input);
            var p = ParseNearbyTickets(input);
            var nearbyTickets = p.Where(x => SumInvalidTicketFields(x, rulesBase) == 0).ToList();

            var fieldPositions = new Dictionary<string, int>();
            var rules = new Dictionary<string, List<Rule>>(rulesBase);

            for (var col = 0; col < 20; col++)
            {
                // TODO: fix error somewhere in this loop
                var field = FindFieldForCol(col, rules, nearbyTickets);
                fieldPositions.Add(field, col);

                if (fieldPositions.Count(x => x.Key.StartsWith("departure")) == 6)
                    break;
            }

            return fieldPositions.Where(x => x.Key.StartsWith("departure"))
                .Aggregate<KeyValuePair<string, int>, long>(1, (current, fieldPosition) => current * long.Parse(myTicket.Values[fieldPosition.Value]));
        }

        private string FindFieldForCol(int col, Dictionary<string, List<Rule>> rules, List<Ticket> nearbyTickets)
        {
            foreach (var (field, r) in rules.ToList())
            {
                if (nearbyTickets.Any(ticket => !IsValueValid(int.Parse(ticket.Values[col]), r)))
                    continue;

                rules.Remove(field);
                return field;
            }

            return null;
        }

        private bool IsValueValid(int value, List<Rule> rules)
        {
            return value >= rules[0].Min && value <= rules[0].Max || value >= rules[1].Min && value <= rules[1].Max;
        }

        private int SumInvalidTicketFields(Ticket ticket, Dictionary<string, List<Rule>> rules)
        {
            var sum = 0;
            foreach (var value in ticket.Values)
            {
                sum += int.Parse(value);
                foreach (var (min, max) in rules.SelectMany(x => x.Value))
                {
                    if (int.Parse(value) < min || int.Parse(value) > max) continue;
                    sum -= int.Parse(value);
                    break;
                }
            }

            return sum;
        }

        private Dictionary<string, List<Rule>> ParseRules(string input)
        {
            var rules = new Dictionary<string, List<Rule>>();
            var rulePart = input.Split($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries)[0];
            var lines = rulePart.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var tokens = line.Split(":", StringSplitOptions.RemoveEmptyEntries);
                var field = tokens[0];
                var rulesStr = tokens[1];
                var rulesTokens = rulesStr.Split(" or ", StringSplitOptions.RemoveEmptyEntries);

                rules.Add(field, new List<Rule>());

                foreach (var ruleToken in rulesTokens)
                {
                    var min = int.Parse(ruleToken.Split("-", StringSplitOptions.RemoveEmptyEntries)[0]);
                    var max = int.Parse(ruleToken.Split("-", StringSplitOptions.RemoveEmptyEntries)[1]);
                    rules[field].Add(new Rule(min, max));
                }
            }

            return rules;
        }

        private Ticket ParseMyTicket(string input)
        {
            var myTicketPart = input.Split($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries)[1];
            var values = myTicketPart.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)[1].Split(",", StringSplitOptions.RemoveEmptyEntries);
            return new Ticket(values.ToList());
        }

        private IEnumerable<Ticket> ParseNearbyTickets(string input)
        {
            var nearbyTickets = input.Split($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries)[2];
            var lines = nearbyTickets.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Skip(1);

            foreach (var line in lines)
                yield return new Ticket(line.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList());
        }
    }
}