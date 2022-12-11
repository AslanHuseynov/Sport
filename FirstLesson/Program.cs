using FirstLesson;
using FirstLesson.Matches;
using FirstLesson.Playoffs;
using FirstLesson.Rules;
using FirstLesson.Teams;
using System.Runtime.InteropServices;



//var match = new Match(new BasketballTeam("Warriors"), new BasketballTeam("Lakers"));
//match.Start();



//var match = new FootballMatch(new FootballTeam("Chelsea"), new FootballTeam("Barcelona"));
//var playoff = new PlayoffRound<FootballTeam>(match, new PlayoffFootballRules());
//playoff.Start();

//var match2 = new FootballMatch(new FootballTeam("Dallas"), new FootballTeam("Miami"));
//var playoff2 = new FootballPlayoffRound(match2);
//playoff2.Start();




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


