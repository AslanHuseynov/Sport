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
        //FirstRound.Start();
        //SecondRound.Start();
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
        Console.WriteLine($"{FirstRound.Away.Name} ({FirstRound.AwayScore}) {FirstRound.AwayScore + SecondRound.HomeScore} -" +
                          $" {FirstRound.HomeScore + SecondRound.AwayScore} ({FirstRound.HomeScore}) {FirstRound.Home.Name} " +
                          $"{penalties} [{GetWinner().Name}]");
    }
    
    private Team GetWinnerWithoutPenalties()
    {
        var sumOfGoalsFirst = FirstRound.HomeScore + SecondRound.AwayScore;
        var sumOfGoalsSecond = SecondRound.HomeScore + FirstRound.AwayScore;
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