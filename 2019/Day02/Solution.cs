using System;
using System.Collections.Generic;

namespace AdventOfCode.Y2019.Day02 {

    class Solution : Solver {

        public string GetName() => "1202 Program Alarm";

        public IEnumerable<object> Solve(string input) {
            yield return PartOne(input);
            yield return PartTwo(input);
        }

        long PartOne(string input) => ExecIntCode(new IntCodeMachine(input), 12, 2);

        int PartTwo(string input) {
            var icm = new IntCodeMachine(input);

            for (var sum = 0; ; sum++) {
                for (var verb = 0; verb <= sum; verb++) {
                    var noun = sum - verb;
                    var res = ExecIntCode(icm, noun, verb);
                    if (res == 19690720) {
                        return 100 * noun + verb;
                    }
                }
            }
            throw new Exception();
        }

        long ExecIntCode(IntCodeMachine icm, int noun, int verb) {
            icm.Reset();
            icm.mem[1] = noun;
            icm.mem[2] = verb;
            icm.Run();
            return icm.mem[0];
        }
    }
}