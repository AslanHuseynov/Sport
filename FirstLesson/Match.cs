using System.Security.Cryptography;
using FirstLesson;

public class Match<TTeam> where TTeam : Team
{
    public TTeam Home;
    public TTeam Away;
    public int HomeGoals;
    public int AwayGoals;
    public bool IsFinished;
    public Match(TTeam home, TTeam away)
    {
        Home = home;
        Away = away;
    }
    public Match(string home, string away)
    {
        Home = (TTeam)Activator.CreateInstance(typeof(TTeam), new object[] { home });
        Away = (TTeam)Activator.CreateInstance(typeof(TTeam), new object[] { away });
    }

    public virtual void Start()
    {
        HomeGoals = GenerateRandomNumber.Generate(1, 6);
        AwayGoals = GenerateRandomNumber.Generate(1, 6);
        IsFinished = true;
    }
 

}