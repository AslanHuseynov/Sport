namespace FirstLesson;

public class PlayoffRound
{
    public Match FirstRound;
    public Match SecondRound;
    public PenaltySeries PenaltySeries;

    public PlayoffRound(Match firstRound)
    {
        FirstRound = firstRound;
        SecondRound = new Match(FirstRound.Away, FirstRound.Home);
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
        PenaltySeries = new PenaltySeries(SecondRound.Home, SecondRound.Away);
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
    
    private Team GetWinnerWithoutPenalties()
    {
        var sumOfGoalsFirst = FirstRound.HomeGoals + SecondRound.AwayGoals;
        var sumOfGoalsSecond = SecondRound.HomeGoals + FirstRound.AwayGoals;
        var winner = sumOfGoalsFirst > sumOfGoalsSecond ? FirstRound.Home :
            sumOfGoalsFirst < sumOfGoalsSecond ? FirstRound.Away : null;
        return winner;
    }
    public Team GetWinner()
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