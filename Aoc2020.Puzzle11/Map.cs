using System.Linq;
using System.Text;

namespace Aoc2020.Puzzle11
{
    public class Map
    {
        private const string Floor = ".";
        private const string OccupiedSeat = "#";
        private const string EmptySeat = "L";

        public string[][] Data { get; }


        public Map(string[][] data)
        {
            Data = new string[data.Length][];

            for (var i = 0; i < data.Length; i++)
            {
                Data[i] = new string[data[i].Length];

                for (var j = 0; j < data[i].Length; j++)
                {
                    Data[i][j] = data[i][j];
                }
            }
        }

        public Map Resolve()
        {
            var baseMap = new Map(Data);
            for (var i = 0; i < Data.Length; i++)
            {
                for (var j = 0; j < Data[i].Length; j++)
                {
                    HandlePosition(baseMap, i, j);
                }
            }

            return this;
        }

        public Map Resolve2()
        {
            var baseMap = new Map(Data);
            for (var i = 0; i < Data.Length; i++)
            {
                for (var j = 0; j < Data[i].Length; j++)
                {
                    HandlePosition2(baseMap, i, j);
                }
            }

            return this;
        }

        public int CountOccupiedSeats()
        {
            return Data.Sum(x => x.Count(y => y == OccupiedSeat));
        }

        private void HandlePosition(Map baseMap, int i, int j)
        {
            var c = baseMap.Data[i][j];
            switch (c)
            {
                case Floor:
                    return;
                case EmptySeat when GetOccupiedAdjacentCount(baseMap, i, j) == 0:
                    Data[i][j] = OccupiedSeat;
                    break;
                case OccupiedSeat when GetOccupiedAdjacentCount(baseMap, i, j) >= 4:
                    Data[i][j] = EmptySeat;
                    break;
            }
        }

        private void HandlePosition2(Map baseMap, int i, int j)
        {
            var c = baseMap.Data[i][j];
            switch (c)
            {
                case Floor:
                    return;
                case EmptySeat when GetOccupiedAdjacentCount2(baseMap, i, j) == 0:
                    Data[i][j] = OccupiedSeat;
                    break;
                case OccupiedSeat when GetOccupiedAdjacentCount2(baseMap, i, j) >= 5:
                    Data[i][j] = EmptySeat;
                    break;
            }
        }

        private int GetOccupiedAdjacentCount(Map map, int i, int j)
        {
            const string c = OccupiedSeat;
            var count = 0;

            if (i > 0)
            {
                if (map.Data[i - 1][j] == c)
                    count++;
                if (j > 0 && map.Data[i - 1][j - 1] == c)
                    count++;
                if (j < map.Data[i].Length - 1 && map.Data[i - 1][j + 1] == c)
                    count++;
            }

            if (i < map.Data.Length - 1)
            {
                if (map.Data[i + 1][j] == c)
                    count++;
                if (j > 0 && map.Data[i + 1][j - 1] == c)
                    count++;
                if (j < map.Data[i].Length - 1 && map.Data[i + 1][j + 1] == c)
                    count++;
            }

            if (j > 0 && map.Data[i][j - 1] == c)
                count++;
            if (j < map.Data[i].Length - 1 && map.Data[i][j + 1] == c)
                count++;

            return count;
        }

        private int GetOccupiedAdjacentCount2(Map map, int i, int j)
        {
            var count = 0;

            if (IsOccupiedInDirection(map, i, j, -1, -1))
                count++;
            if (IsOccupiedInDirection(map, i, j, -1, 0))
                count++;
            if (IsOccupiedInDirection(map, i, j, -1, 1))
                count++;
            if (IsOccupiedInDirection(map, i, j, 0, -1))
                count++;
            if (IsOccupiedInDirection(map, i, j, 0, 1))
                count++;
            if (IsOccupiedInDirection(map, i, j, 1, -1))
                count++;
            if (IsOccupiedInDirection(map, i, j, 1, 0))
                count++;
            if (IsOccupiedInDirection(map, i, j, 1, 1))
                count++;

            return count;
        }

        private bool IsOccupiedInDirection(Map map, int i, int j, int x, int y)
        {
            while (true)
            {
                i += y;
                j += x;

                if (i < 0 || i >= map.Data.Length || j < 0 || j >= map.Data[0].Length)
                    break;

                switch (map.Data[i][j])
                {
                    case EmptySeat:
                        return false;
                    case OccupiedSeat:
                        return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var row in Data)
            {
                foreach (var col in row)
                {
                    sb.Append(col);
                }

                sb.Append('\n');
            }

            return sb.ToString().TrimEnd();
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Map)
                return false;

            return ((Map) obj).ToString() == ToString();
        }

        public override int GetHashCode()
        {
            return Data != null ? Data.GetHashCode() : 0;
        }
    }
}