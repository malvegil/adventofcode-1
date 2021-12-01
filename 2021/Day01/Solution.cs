using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Y2021.Day01;

[ProblemName("Sonar Sweep")]
class Solution : Solver {

    public object PartOne(string input) => CountIncreases(Numbers(input));

    public object PartTwo(string input) => CountIncreases(BlockSums(Numbers(input)));

    int CountIncreases(int[] ns) {
        int increases = 0;
        for (int i = 1; i < ns.Count(); i++)
        {
            if (ns[i - 1] < ns[i]) increases++;
        }
        return increases;
    }

    List<int[]> Blocks(int[] ns, int size)
    {
        List<int[]> blocks = new List<int[]>();
        for (int i = 0; i < ns.Length - size + 1; i++)
        {
            blocks.Add(ns[i..(i + size)]);
        }
        return blocks;
    }

    int[] BlockSums(int[] ns) => (from r in Blocks(ns, 3) select r.Sum()).ToArray();
    
    int[] Numbers(string input) => (from n in input.Split('\n') select int.Parse(n)).ToArray();
}
