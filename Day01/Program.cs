// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var filename = "example.txt";
filename = "input";
var dial = 50;
var Part1Password = 0;
var Part2Password = 0;

foreach(var line in File.ReadLines(filename)) {
    char direction = line.Take(1).Single();
    var clicks = int.Parse(line[1..]);
    Part2Password += clicks / 100;
    clicks %= 100;
    if(direction == 'L') {
        clicks = -clicks;
    }

    Console.WriteLine($"{dial}, {dial+clicks}");
    if (dial != 0 && (dial + clicks > 100 || dial + clicks < 0) ){
        Part2Password += 1;
    }

    dial = (100 + dial + clicks) % 100;
    if (dial == 0) {
        Part1Password += 1;
    }

    // Console.WriteLine(dial);
}
Console.WriteLine(Part1Password);
Console.WriteLine(Part2Password);
Console.WriteLine(Part1Password + Part2Password);
