using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode.Y2021.Day04;

[ProblemName("Giant Squid")]      
class Solution : Solver {

    public object PartOne(string input) {
        var nums = RandomNumbers(input);
        var boards = Boards(input);
        var num_boards = boards.Length / 25;
            
        var solution_found = false;
        var solved_board = -1;
        var i = 0;
        while(!solution_found && i < nums.Length)
        {
            Enumerable.Range(0, nums.Length)
                .Select(x =>
                    boards[x] = (boards[x] == nums[i] ? -1 : boards[x])
                );

            if (i >= 4) // at least 5 numbers for a match
            {
                for(var b = 0; b < num_boards; b++)
                {
                    // solution_found = IsBingo(boards[0..24]);
                    if (solution_found) solved_board = b;
                };
            }
            i++;
        };

        Console.WriteLine(boards.Length);

        // int[]
        // loop through all numbers
        // loop through all boards
        // loop 1-5 through rows (write value if found, sum if not) check for full row
        // loop 1-5 through columns (write value if found, sum if not) check for full column

        return 0;
    }

    public object PartTwo(string input) {
        return 0;
    }

    // var regex = new Regex(@"(?<n>\d+)");

    static int[] RandomNumbers(string input) => 
        (from n in input.Split('\n') 
         select n.Split(',').ToList())
         .First()
         .Select(c => int.Parse(c))
         .ToArray();
    
    static int[] Boards(string input) => 
        (from n in input.Split('\n')
         where n.Length > 0 && !n.Contains(",")
         select n.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
        )
        .SelectMany(c => int.Parse(c))
        .ToArray();
    
    static bool IsBingo(int[] board) 
    {
        // check rows
        // Enumerable.Range(0, 5).All(y => board[])
        // for(var x = 0; x < 5; x++)
        // {
        //     for (var y = 0; y < 5; y++)
        //     {

        //     }
        // }
        // // check columns

		// // check if all of row/column is set;
		// // only need to check the row and column where we
		// // just set a flag, since others won't have changed status
		// Enumerable.Range(0, 5).All(_y => board[x, _y])
		// || Enumerable.Range(0, 5).All(_x => board[_x, y]);

        return true;
    }
}
