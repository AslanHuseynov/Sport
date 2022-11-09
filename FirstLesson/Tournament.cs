namespace FirstLesson;

public class Tournament<TTeam> where TTeam : Team
{
    private string Name;
    private List<TTeam> Teams;
    private List<TTeam> CurrentTeams;
    public Tournament(string name, List<TTeam> teams)
    {
        Name = name;
        Teams = teams;
        CurrentTeams = teams;
    }

    private List<Match<TTeam>> Draw()
    {
        var matches = new List<Match<TTeam>>();
        while (CurrentTeams.Count > 0)
        {
            var match = GenerateRandomMatch.GenerateMatch(CurrentTeams);
            matches.Add(match);
        }

        return matches;
    }
    public Team GetWinnerRecursive()
    {
        if (CurrentTeams.Count == 1)
            return CurrentTeams.First();
        
        var matches = CurrentTeams.Count == 2 ? 
            new [] 
            { new Match<TTeam>(CurrentTeams.First(), CurrentTeams.Last())}
            .ToList()  
            : Draw();
        if (matches.Count == 1)
        {
            
            var incompleteMatch = matches.First();
            var final = new FinalMatch<TTeam>(incompleteMatch.Home, incompleteMatch.Away);
            final.Start();
            CurrentTeams = new [] {final.GetWinner()}.ToList();
            var penaltiesScore = final?.PenaltySeries != null ? final.PenaltySeries.GetScore() : string.Empty;  
            Console.WriteLine($"{final.Home.Name} {final.HomeGoals} - {final.AwayGoals} {final.Away.Name} {penaltiesScore}");
            
        }


        else
        {
            var playoffRounds = matches.Select(x => new PlayoffRound<TTeam>(x)).ToList();

            foreach (var playoffRound in playoffRounds)
            {
                playoffRound.Start();
            }    
            
            CurrentTeams = playoffRounds.Select(x => x.GetWinner()).ToList();
        }

        Console.WriteLine("Next Stage");
        var team = GetWinnerRecursive();
        return team;
    }
}