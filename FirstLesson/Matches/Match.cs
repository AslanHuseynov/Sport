using FirstLesson;

public abstract class Match<TTeam> where TTeam : Team
{
    public TTeam Home;
    public TTeam Away;
    public int HomeScore;
    public int AwayScore;
    public bool IsFinished;

    public Match(TTeam home, TTeam away) 
    {
        Home = home;
        Away = away;
    }
    public abstract void Start();
    public void Start(int start, int end)
    {
        HomeScore = GenerateRandomNumber.Generate(start, end);
        AwayScore = GenerateRandomNumber.Generate(start, end);
        IsFinished = true;
    }

    public abstract Match<TTeam> Reverse();
}

