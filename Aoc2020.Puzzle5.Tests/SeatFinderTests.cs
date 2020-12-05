using System;
using System.Runtime.InteropServices;
using Shouldly;
using Xunit;

namespace Aoc2020.Puzzle5.Tests
{
    public class SeatFinderTests
    {
        private readonly SeatFinder _seatFinder = new();

        [Theory]
        [InlineData("FBFBBFFRLR", 357)]
        [InlineData("BFFFBBFRRR", 567)]
        [InlineData("FFFBBBFRRR", 119)]
        [InlineData("BBFFBBFRLL", 820)]
        public void ShouldFindSeatsId(string spec, int id)
        {
            _seatFinder.FindSeatId(spec).ShouldBe(id);
        }
    }
}