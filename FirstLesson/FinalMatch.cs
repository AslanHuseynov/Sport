namespace FirstLesson;

public class FinalMatch : Match
{
    public FinalMatch(Team home, Team away) 
        : base(home, away)
    {
    }

    public FinalMatch(string home, string away) : base(home, away)
    {
    }


    public PenaltySeries PenaltySeries;

    public void Start()
    {
        //base.Start();
        if (HomeGoals == AwayGoals)
        {
            PenaltySeries = new PenaltySeries(Home, Away);
            PenaltySeries.Start(1, 6);
        }
    }

    public Team GetWinner() 
    {
        if (!IsFinished)
            throw new InvalidOperationException("The match has yet to start!");
            

        if (HomeGoals > AwayGoals)
        {
            return Home;
        }
        else if (HomeGoals == AwayGoals)
        {
            if (PenaltySeries.FirstGoals > PenaltySeries.SecondGoals)
                return PenaltySeries.TeamFirst;
            else
                return PenaltySeries.TeamSecond;
        }
        return Away;
         
    }
}