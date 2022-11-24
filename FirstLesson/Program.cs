using FirstLesson;
using FirstLesson.Matches;
using FirstLesson.Rules;
using FirstLesson.Teams;
using System.Runtime.InteropServices;



//var match = new Match(new BasketballTeam("Warriors"), new BasketballTeam("Lakers"));
//match.Start();



var match = new FootballMatch(new FootballTeam("Chelsea"), new FootballTeam("Barcelona"));
var playoff = new PlayoffRound<FootballTeam>(match, new PlayoffFootballRules());
playoff.Start();

var match2 = new BasketballMatch(new BasketballTeam("Dallas"), new BasketballTeam("Miami"));
var playoff2 = new PlayoffRound<BasketballTeam>(match2, new PlayoffBasketballRules());
playoff2.Start();


return;


var teamNames = new string[]
{
    "Napoli", "Liverpool", "Chelsea", "Arsenal",
    "Porto", "Barcelona", "Real Madrid", "Atletico Madrid", "Sevilia", "Milan", "Inter", "Karabagh", "PSG", "Lyon",
    "Manchester City", "Bayern"
};


var footballTeams = teamNames.Select(x => new FootballTeam(x)).ToList();
var mat = GenerateRandomMatch.GenerateMatch<FootballMatch, FootballTeam>(footballTeams);


//var a = 5;
//var tournament = new Tournament("Uefa Champions League", teams);
//var winner = tournament.GetWinnerRecursive();
//Console.WriteLine($"winner is {winner.Name}");




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