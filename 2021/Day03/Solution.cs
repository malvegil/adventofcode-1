using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode.Y2021.Day03;

[ProblemName("Binary Diagnostic")]      
class Solution : Solver {

    public object PartOne(string input) {
        var diags = Diagnostics(input);
        var sums = Enumerable.Range(0, diags[0].Length)
           .Select(
               i => diags.Select(s => s[i]).Sum()
           )
           .ToArray();
        
        var gamma = new StringBuilder();
        var epsilon = new StringBuilder();
        for (var i = 0; i < diags[0].Length; i++)
        {
            gamma.Append(sums[i] > diags.Count() / 2 ? "1" : "0");
            epsilon.Append(sums[i] < diags.Count() / 2 ? "1" : "0");
        }
        
        return Convert.ToInt32(gamma.ToString(), 2) * Convert.ToInt32(epsilon.ToString(), 2);
    }

    public object PartTwo(string input) {
        var oxgen = Diagnostics(input);
        var cdiox = Diagnostics(input);

        var i = 0;
        var sum = 0;
        while (oxgen.Count() > 1)
        {
            sum = oxgen.Select(s => s[i]).Sum();
            oxgen = oxgen.Where(x => x[i] == (sum >= oxgen.Count() / 2 ? 1 : 0)).ToList();
            i++;
        }
        i = 0;
        while (cdiox.Count() > 1)
        {
            sum = cdiox.Select(s => s[i]).Sum();
            cdiox = cdiox.Where(x => x[i] != (sum >= cdiox.Count() / 2 ? 1 : 0)).ToList();
            i++;
        }

        var o = new StringBuilder();
        var c = new StringBuilder();
        for (var j = 0; j < oxgen[0].Length; j++)
        {
            o.Append(oxgen[0][j]);
            c.Append(cdiox[0][j]);
        }

        return Convert.ToInt32(o.ToString(), 2) * Convert.ToInt32(c.ToString(), 2);
    }

    List<int[]> Diagnostics(string input) => (from n in input.Split('\n') select Array.ConvertAll(n.ToCharArray(), c => (int)Char.GetNumericValue(c))).ToList();

    
}
