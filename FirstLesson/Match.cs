using System.Security.Cryptography;
using FirstLesson;

public class Match
{
    public Team Home;
    public Team Away;
    public int HomeGoals;
    public int AwayGoals;
    public bool IsFinished;
    public Match(Team home, Team away)
    {
        Home = home;
        Away = away;
    }
    public Match(string home, string away)
    {
        Home = (Team)Activator.CreateInstance(typeof(Team), new object[] { home });
        Away = (Team)Activator.CreateInstance(typeof(Team), new object[] { away });
    }

    public virtual void Start()
    {
        HomeGoals = GenerateRandomNumber.Generate(1, 6);
        AwayGoals = GenerateRandomNumber.Generate(1, 6);
        IsFinished = true;
    }
 

}