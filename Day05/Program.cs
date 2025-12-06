

// var filename = "example.txt";
var filename = "input";

var Part1Answer = 0;
long Part2Answer = 0;

List<Tuple<long,long>> fresh = [];
List<long> items = [];

foreach(var line in File.ReadLines(filename)) {
    if(line.Contains('-')) {
        var splitline = line.Split('-');
        fresh.Add(new Tuple<long,long>(long.Parse(splitline[0]), long.Parse(splitline[1])));
    }
    else {
        if(!string.IsNullOrWhiteSpace(line)) {
            items.Add(long.Parse(line));
        }
    }
}

fresh = fresh.OrderBy(x => x.Item1).ToList();

long maxi = 0;
foreach(var range in fresh) {
    if(range.Item2 > maxi) {
        var start = long.Max(maxi+1, range.Item1);
        var end = range.Item2;

        Part2Answer += 1 + (end - start);
        maxi = end;
    }
}

foreach(var item in items) {
    foreach(var range in fresh) {
        if(item >= range.Item1) {
            if(item <= range.Item2) {
                Part1Answer += 1;
                break;
            }
        }
        else {
            break;
        }
    }
}

Console.WriteLine(Part1Answer);
Console.WriteLine(Part2Answer);
