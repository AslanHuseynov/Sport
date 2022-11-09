namespace FirstLesson;

public class PlayoffRound<TTeam> where TTeam : Team
{
    public Match<TTeam> FirstRound;
    public Match<TTeam> SecondRound;
    public PenaltySeries<TTeam> PenaltySeries;

    public PlayoffRound(Match<TTeam> firstRound)
    {
        FirstRound = firstRound;
        SecondRound = new Match<TTeam>(FirstRound.Away, FirstRound.Home);
    }
    
    // Inter (1) 4-3 (2) Liverpool Pen: 
    public void Start()
    {
        FirstRound.Start();
        SecondRound.Start();
        var winner = GetWinnerWithoutPenalties();
        if (winner != null)
        { 
            PrintResult();
            return;
        }
        PenaltySeries = new PenaltySeries<TTeam>(SecondRound.Home, SecondRound.Away);
        PenaltySeries.Start(1, 6);
        PrintResult();
    }

    private void PrintResult()
    {
        var penalties = PenaltySeries != null ? PenaltySeries.GetScore() : string.Empty;
        Console.WriteLine($"{FirstRound.Away.Name} ({FirstRound.AwayGoals}) {FirstRound.AwayGoals + SecondRound.HomeGoals} -" +
                          $" {FirstRound.HomeGoals + SecondRound.AwayGoals} ({FirstRound.HomeGoals}) {FirstRound.Home.Name} " +
                          $"{penalties} [{GetWinner().Name}]");
    }
    
    private TTeam GetWinnerWithoutPenalties()
    {
        var sumOfGoalsFirst = FirstRound.HomeGoals + SecondRound.AwayGoals;
        var sumOfGoalsSecond = SecondRound.HomeGoals + FirstRound.AwayGoals;
        var winner = sumOfGoalsFirst > sumOfGoalsSecond ? FirstRound.Home :
            sumOfGoalsFirst < sumOfGoalsSecond ? FirstRound.Away : null;
        return winner;
    }
    public TTeam GetWinner()
    {
        if (!FirstRound.IsFinished || !SecondRound.IsFinished)
            throw new InvalidOperationException("");

        var winner = GetWinnerWithoutPenalties();
        if (winner != null)
            return winner;

        return PenaltySeries.FirstGoals > PenaltySeries.SecondGoals
            ? PenaltySeries.TeamFirst
            : PenaltySeries.TeamSecond;

    }
    
}