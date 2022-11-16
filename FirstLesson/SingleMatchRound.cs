namespace FirstLesson;

public class SingleMatchRound<TTeamSingle> : Match<TTeamSingle> where TTeamSingle : Team
{
    public SingleMatchRound(TTeamSingle home, TTeamSingle away) 
        : base(home, away)
    {
    }

    public PenaltySeries PenaltySeries;
    public override void Start()
    {
        //base.Start();
        if (HomeScore == AwayScore)
        {
            PenaltySeries = new PenaltySeries(Home, Away);
            PenaltySeries.Start(1, 6);
        }
    }

    public Team GetWinner() 
    {
        if (!IsFinished)
            throw new InvalidOperationException("The match has yet to start!");
            

        if (HomeScore > AwayScore)
        {
            return Home;
        }
        else if (HomeScore == AwayScore)
        {
            if (PenaltySeries.FirstGoals > PenaltySeries.SecondGoals)
                return PenaltySeries.TeamFirst;
            else
                return PenaltySeries.TeamSecond;
        }
        return Away;
         
    }

}