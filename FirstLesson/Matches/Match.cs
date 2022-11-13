using System.Security.Cryptography;
using FirstLesson;

public  class Match
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
        Home = new Team(home);
        Away = new Team(away);
    }

    public virtual void Start()
    {

    }


    public void Start(int start, int end)
    {
        HomeGoals = GenerateRandomNumber.Generate(start, end);
        AwayGoals = GenerateRandomNumber.Generate(start, end);
        IsFinished = true;
    }


}