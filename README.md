# Advent of Code 2023 Solutions

This is Steve Ognibene's solutions to Advent of Code 2023 done in C# with .NET 8.

## Commentary

### Day 1

Completed 2023-12-02.  Part one was pretty straight-forward to solve with `IndexOfAny` and `LastIndexOfAny`, however part 2 increased in complexity a lot I think.  I went with a Linq solution.  I was running into `SequenceContainsNoElements` exceptions, but I remembered about `DefaultIfEmpty` which worked around the problem.  I feel like the solution is a bit long for day 1 - maybe I missed some trick to simplify it.

Note that VS suggested using a primary constructor (ok), to use a `SearchValues` (very cool), and to deconstruct the minby to two ints.  I'm not convinced on the deconstruction one because it means the variable names were really long, but the primary constructor did save some code and also the `SearchValues` suggestion was really impressive because it was even able to take the strings as spans to enable the method call.

