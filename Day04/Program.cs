
using System.ComponentModel.DataAnnotations;

var watch = System.Diagnostics.Stopwatch.StartNew();

var filename = "example.txt";
// var filename = "input";

long Part1Answer = 0;
long Part2Answer = 0;

List<string> map = [.. File.ReadLines(filename)];

char[,] maparray = new char[map.Count, map[0].Length];
for(int i=0; i < map.Count; i++) {
    for(int j=0; j < map[0].Length; j++) {
        maparray[i,j] = map[i][j];
    }
}

int CountNeighbours(char[,] maparray, int i, int j) {
    var total_neighbours = -1;
    var mini = Math.Max(0, i-1);
    var minj = Math.Max(0, j-1);
    var maxi = Math.Min(maparray.GetLength(0)-1, i + 1);
    var maxj = Math.Min(maparray.GetLength(1)-1, j + 1);
    foreach(var m in Enumerable.Range(mini, 1+ maxi - mini)) {
        foreach(var n in Enumerable.Range(minj, 1+ maxj - minj)) {
            total_neighbours += (maparray[m,n] == '@') ? 1 : 0;
        }
    }
    return total_neighbours;
}

for(int i=0; i < maparray.GetLength(0); i++) {
    for(int j=0; j < maparray.GetLength(1); j++) {
        if(maparray[i,j] != '@') {
            continue;
        }
        var total_neighbours = CountNeighbours(maparray, i, j);
        if(total_neighbours < 4) {
            Part1Answer += 1;
        }
    }
}

bool changed = true;
while(changed) {
    changed = false;
    for(int i=0; i < maparray.GetLength(0); i++) {
        for(int j=0; j < maparray.GetLength(1); j++) {
            if(maparray[i,j] != '@') {
                continue;
            }
            var total_neighbours = CountNeighbours(maparray, i, j);
            if(total_neighbours < 4) {
                Part2Answer += 1;
                maparray[i,j] = 'X';
                changed = true;
            }
        }
    }
}


Console.WriteLine($"Part1: {Part1Answer}");
Console.WriteLine($"Part2: {Part2Answer}");

watch.Stop();
var elapsedMs = watch.ElapsedMilliseconds;
Console.WriteLine($"Elapsed {elapsedMs} ms");
