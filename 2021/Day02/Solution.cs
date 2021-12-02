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
        var height = (from d in dir where (d.Item1).StartsWith('u') select -d.Item2).Sum() + (from d in dir where (d.Item1).StartsWith('d') select d.Item2).Sum();

        return distance * height;
    }

    public object PartTwo(string input) {
        return 0;
    }

    List<Tuple<string,int>> Directions(string input) => (from n in input.Split('\n') select new Tuple<string,int>(n.Split(' ')[0],int.Parse(n.Split(' ')[1]))).ToList();
}
