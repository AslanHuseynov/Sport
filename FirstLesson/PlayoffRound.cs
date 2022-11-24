using FirstLesson.Matches;
using FirstLesson.Rules;

namespace FirstLesson;



public class A
{
}

public class PlayoffRound<TTeam> where TTeam : Team
{
    public List<Match<TTeam>> Rounds;
    public Match<TTeam> FirstRound;
    public Match<TTeam> SecondRound;
    public PenaltySeries PenaltySeries;
    public PlayoffRules Rules;


    public PlayoffRound(Match<TTeam> firstRound, PlayoffRules rules)
    {
        Rounds = new List<Match<TTeam>>();
        Rules = rules;
        var range = Enumerable.Range(1, rules.MinGameQunatity);
        Rounds.Add(firstRound);

        for (int i = 0; i < range.Count(); i++)
        {
            if (i % 2 != 0)
            {
                Rounds.Add(firstRound.Reverse().Reverse());
            }
            else
                Rounds.Add(firstRound.Reverse());
        }
        //Rounds.Add(firstRound.Reverse());
        FirstRound = firstRound;
        SecondRound = FirstRound.Reverse();
    }

    public void Start()
    {
        foreach (var item in Rounds)
        {
            item.Start();
        }

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
        if (!Rounds.All(x => x.IsFinished))
            throw new InvalidOperationException("");

        var winner = GetWinnerWithoutPenalties();
        if (winner != null)
            return winner;

        return PenaltySeries.FirstGoals > PenaltySeries.SecondGoals
            ? PenaltySeries.TeamFirst
            : PenaltySeries.TeamSecond;

    }

}