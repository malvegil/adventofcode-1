using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode.Y2021.Day02;

[ProblemName("Dive!")]      
class Solution : Solver {

    public object PartOne(string input) {
        var dir = Directions(input);
        var distance = (from d in dir where (d.Item1).StartsWith('f') select d.Item2).Sum();
        var depth = (from d in dir where (d.Item1).StartsWith('u') select -d.Item2).Sum() + (from d in dir where (d.Item1).StartsWith('d') select d.Item2).Sum();

        return distance * depth;
    }

    public object PartTwo(string input) {
        var dir = Directions(input);
        var distance = (from d in dir where (d.Item1).StartsWith('f') select d.Item2).Sum();
        long depth = 0;
        long aim = 0;

        foreach (var d in dir)
        {
            switch(d.Item1)
            {
                case "forward":
                    depth += (d.Item2 * aim);
                    break;
                case "up":
                    aim -= d.Item2;
                    break;
                case "down":
                    aim += d.Item2;
                    break;
            }
        }

        return depth * distance;
    }

    List<Tuple<string,int>> Directions(string input) => (from n in input.Split('\n') select new Tuple<string,int>(n.Split(' ')[0],int.Parse(n.Split(' ')[1]))).ToList();
}
