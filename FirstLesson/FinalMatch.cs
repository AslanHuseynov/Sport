namespace FirstLesson;

public class FinalMatch<TTeam> : Match<TTeam> where TTeam : Team
{
    public FinalMatch(TTeam home, TTeam away) 
        : base(home, away)
    {
    }

    public FinalMatch(string home, string away) : base(home, away)
    {
    }


    public PenaltySeries<TTeam> PenaltySeries;

    public override void Start()
    {
        base.Start();
        if (HomeGoals == AwayGoals)
        {
            PenaltySeries = new PenaltySeries<TTeam>(Home, Away);
            PenaltySeries.Start(1, 6);
        }
    }

    public TTeam GetWinner() 
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