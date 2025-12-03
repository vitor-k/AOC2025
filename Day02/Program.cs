
var watch = System.Diagnostics.Stopwatch.StartNew();

// var filename = "example.txt";
var filename = "input";

long Part1Answer = 0;
long Part2Answer = 0;

var text = File.ReadAllText(filename);

long Part1(string ns) {
    var len = ns.Length;
    if(len % 2 == 1) {
        return 0;
    }
    if(ns[..(len/2)] == ns[(len / 2)..]) {
        return long.Parse(ns);
    }
    return 0;
}

long Part2(string ns) {
    var len = ns.Length;

    for(int i=1; i<=len/2; i++) {
        if (len % i != 0) {
            continue;
        }
        // var chunks = ns.Chunk(i);
        // if (chunks.All(o => o.SequenceEqual(chunks.First()))) {
        //     return long.Parse(ns);
        // }
        bool valid = true;
        for(int j=i; j+i<=len; j+=i) {
            if (ns[j..(j+i)] != ns[..i]) {
                valid = false;
                break;
            }
        }
        if(valid) {
            return long.Parse(ns);
        }
    }
    return 0;
}

foreach(var range in text.Split(',').AsParallel().AsUnordered()) {
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

    Part1Answer += ParallelEnumerable.Range(begin, end-begin+1).AsUnordered().Sum(n => Part1(prefix + n.ToString()));
    Part2Answer += ParallelEnumerable.Range(begin, end-begin+1).AsUnordered().Sum(n => Part2(prefix + n.ToString()));
}
Console.WriteLine(Part1Answer);
Console.WriteLine(Part2Answer);

watch.Stop();
var elapsedMs = watch.ElapsedMilliseconds;
Console.WriteLine($"Elapsed {elapsedMs} ms");
