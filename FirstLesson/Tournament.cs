//namespace FirstLesson;

//public class Tournament<TTeam> where TTeam : Team
//{
//    private string Name;
//    private List<TTeam> Teams;
//    private List<TTeam> CurrenTeams;
//    public Tournament(string name, List<TTeam> teams)
//    {
//        Name = name;
//        Teams = teams;
//        CurrenTeams = teams;
//    }

//    private List<Match<TTeam>> Draw()
//    {
//        var matches = new List<Match<TTeam>();
//        while (CurrenTeams.Count > 0)
//        {
//            var match = GenerateRandomMatch.GenerateMatch<>(CurrenTeams);
//            matches.Add(match);
//        }

//        return matches;
//    }

//    public Team GetWinnerRecursive()
//    {
//        if (CurrenTeams.Count == 1)
//            return CurrenTeams.First();

//        var matches = CurrenTeams.Count == 2 ?
//            new[]
//            { new Match(CurrenTeams.First(), CurrenTeams.Last())}
//            .ToList()
//            : Draw();
//        if (matches.Count == 1)
//        {

//            var incompleteMatch = matches.First();
//            var final = new FinalMatch(incompleteMatch.Home, incompleteMatch.Away);
//            final.Start();
//            CurrenTeams = new[] { final.GetWinner() }.ToList();
//            var penaltiesScore = final?.PenaltySeries != null ? final.PenaltySeries.GetScore() : string.Empty;
//            Console.WriteLine($"{final.Home.Name} {final.HomeScore} - {final.AwayScore} {final.Away.Name} {penaltiesScore}");

//        }


//        else
//        {
//            var playoffRounds = matches.Select(x => new PlayoffRound(x)).ToList();

//            foreach (var playoffRound in playoffRounds)
//            {
//                playoffRound.Start();
//            }

//            CurrenTeams = playoffRounds.Select(x => x.GetWinner()).ToList();
//        }

//        Console.WriteLine("Next Stage");
//        var team = GetWinnerRecursive();
//        return team;
//    }
//}