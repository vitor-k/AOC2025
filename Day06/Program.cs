
// var filename = "example.txt";
using System.IO.Enumeration;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

// var filename = "example.txt";
var filename = "input";

long Part1Answer = 0;
long Part2Answer = 0;

List<List<string>> problemsp1 = new();
List<string> input = new();

foreach(var line in File.ReadLines(filename)) {
    input.Add(line);
    problemsp1.Add(line.Trim().Split([' '], StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList());
}

long Part2(List<string> input) {
    var answer = 0L;
    var partialResult = 0L;
    var operation = '+';
    for(int j=0;j<input[0].Length; j++) {
        if(input[input.Count-1][j] != ' ') {
            answer += partialResult;
            partialResult = 0L;
            operation = input[input.Count-1][j];
        }
        var s_number = "";
        for(int i=0; i<input.Count-1; i++) {
            s_number += input[i][j];
        }
        if (string.IsNullOrWhiteSpace(s_number)) {
            continue;
        }
        if(operation == '+') {
            partialResult += long.Parse(s_number);
        }
        else {
            partialResult = partialResult == 0 ? long.Parse(s_number) : partialResult * long.Parse(s_number);
        }
    }
    answer += partialResult;
    return answer;
}

Part2Answer = Part2(input);

var nproblems = problemsp1[0].Count;

for(int j = 0; j<nproblems; j++) {
    var operation = problemsp1[problemsp1.Count-1][j];
    var result1 = long.Parse(problemsp1[0][j]);

    for(int i = 1; i < problemsp1.Count-1; i++) {
        if(operation == "+") {
            result1 += long.Parse(problemsp1[i][j]);
        }
        else {
            result1 *= long.Parse(problemsp1[i][j]);
        }
    }

    Part1Answer += result1;
}

Console.WriteLine(Part1Answer);
Console.WriteLine(Part2Answer);
