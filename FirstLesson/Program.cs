using FirstLesson;

var teamNames = new string[]
{
    "Napoli", "Liverpool", "Chelsea", "Arsenal",
    "Porto", "Barcelona", "Real Madrid", "Atletico Madrid", "Sevilia", "Milan", "Inter", "Karabagh", "PSG", "Lyon",
    "Manchester City", "Bayern"
};

var basketballNames = new string[] { "Lakers", "Miami", "Dallas", "Toronto" };

var teams = teamNames.Select(x => new Team(x)).ToList();
var tournament = new Tournament("Uefa Champions League", teams);
var winner = tournament.GetWinnerRecursive();
Console.WriteLine($"winner is {winner.Name}");




//var b = teamNames[a];

// var length = teamNames.Length;
//
// var match1 = new Match("Chelsea", "Liverpool");
// match1.Start();
// var winnerForFirst = match1.GetWinner();
//
//
// var match2 = new Match("Barcelona", "Real Madrid");
// match2.Start();
//
// var winnerForSecond = match2.GetWinner();
//
// Console.WriteLine("Final");
//
// var final = new Match(winnerForFirst, winnerForSecond);
// final.Start();
//
// var finalUclWinner = final.GetWinner();