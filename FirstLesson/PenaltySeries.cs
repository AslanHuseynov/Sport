namespace FirstLesson;

public class PenaltySeries<TTeam> where TTeam : Team
{
    public TTeam TeamFirst;
    public TTeam TeamSecond;

    public int FirstGoals;
    public int SecondGoals;

    public PenaltySeries(TTeam teamFirst, TTeam teamSecond)
    {
        TeamFirst = teamFirst;
        TeamSecond = teamSecond;
    }

    public string GetScore()
    {
        return $"Pen: {FirstGoals} - {SecondGoals}";
    }
    
    public void Start(int start, int end)
    {
        var homePenalties = GenerateRandomNumber.Generate(start, end);

        var awayPenalties = GenerateRandomNumber.Generate(start, end);
        FirstGoals = FirstGoals + homePenalties;
        SecondGoals = SecondGoals + awayPenalties;
        if (homePenalties == awayPenalties)
            Start(0, 2);
    }
    
}