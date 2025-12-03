
var watch = System.Diagnostics.Stopwatch.StartNew();

// var filename = "example.txt";
var filename = "input";

long Part1Answer = 0;
long Part2Answer = 0;

foreach(var bank in File.ReadLines(filename)) {
    var maximum = bank.Max();
    string joltage;
    if(bank.IndexOf(maximum) == bank.Length - 1) {
        joltage = $"{bank[..(bank.Length-1)].Max()}{maximum}";
    }
    else {
        joltage = $"{maximum}{bank.Skip(bank.IndexOf(maximum)+1).Max()}";
    }

    var joltage2 = "";
    var start = 0;
    for(int i = 0; i < 12; i++) {
        maximum = bank[start..(bank.Length-11+i)].Max();
        start += bank[start..(bank.Length-11+i)].IndexOf(maximum) + 1;
        joltage2 += maximum;
    }
    Console.WriteLine(joltage2);
    
    Part1Answer += int.Parse(joltage);
    Part2Answer += long.Parse(joltage2);
}
Console.WriteLine($"Part1: {Part1Answer}");
Console.WriteLine($"Part2: {Part2Answer}");

watch.Stop();
var elapsedMs = watch.ElapsedMilliseconds;
Console.WriteLine($"Elapsed {elapsedMs} ms");
