// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

var watch = System.Diagnostics.Stopwatch.StartNew();

// var filename = "example.txt";
var filename = "input";

decimal Part1Answer = 0;
decimal Part2Answer = 0;

var text = File.ReadAllText(filename);

foreach(var range in text.Split(',')) {
    var extremes = range.Split('-');

    var prefix = "";
    for(int i=0; i < extremes[0].Length; i++) {
        if (extremes[0][..i] == extremes[1][..i]) {
            prefix = extremes[0][..i];
        }
    }
    var nskip = prefix.Length;

    var begin = int.Parse(extremes[0][nskip..]);
    var end = int.Parse(extremes[1][nskip..]);

    foreach(var n in Enumerable.Range(begin, end-begin+1)) {
        var ns = prefix + n.ToString();
        var len = ns.Length;

        for(int i=1; i<=len/2; i++)
        {
            var chunks = ns.Chunk(i);
            if (chunks.All(o => new string(o) == new string(chunks.First()))) {
                // Console.WriteLine($"{ns}: {System.Text.Json.JsonSerializer.Serialize(chunks)}");
                Part2Answer += decimal.Parse(ns);
                break;
            }
        }

        // Part 1
        if(len % 2 == 1) {
            continue;
        }
        if(ns[..(len/2)] == ns[(len / 2)..])
        {
            // Console.WriteLine($"{prefix}, {n}");
            Part1Answer += decimal.Parse(ns);
        }
    }
}
Console.WriteLine(Part1Answer);
Console.WriteLine(Part2Answer);

watch.Stop();
var elapsedMs = watch.ElapsedMilliseconds;
Console.WriteLine($"Elapsed {elapsedMs} ms");
