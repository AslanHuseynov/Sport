var intarray = new int[] { 1, 2, 3,4,5,6,7,8,9,10,11 };
var footballShirts = new List<FootballShirt>(); 
foreach (var item in intarray)
{
    var shirt = new FootballShirt(item);
    footballShirts.Add(shirt);
}
var match1 = new Match("Chelsea", "Liverpool", footballShirts);
match1.Start();
var winnerForFirst = match1.GetWinner();


var match2 = new Match("Barcelona", "Real Madrid", footballShirts);
match2.Start();

var winnerForSecond = match2.GetWinner();

Console.WriteLine("Final");

var final = new Match(winnerForFirst,winnerForSecond);
final.Start();

var finalUclWinner = final.GetWinner();