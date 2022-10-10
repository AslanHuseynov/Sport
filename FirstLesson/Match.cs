using System.Security.Cryptography;
using FirstLesson;

class Match
{
    public Team Home;
    public Team Away;
    public int HomeGoals;
    public int AwayGoals;
    public Match(Team home, Team away)
    {
        Home = home;
        Away = away;
    }
    public Match(string home, string away, List<FootballShirt> footballShirts)
    {
        Home = new Team(home,footballShirts);
        Away = new Team(away, footballShirts);
    }

    public void Start()
    {
        HomeGoals = GenerateRandomNumber.Generate();
        AwayGoals = GenerateRandomNumber.Generate();
        
        if (HomeGoals == AwayGoals)
        {
            ShootPenalties();
        }
        Console.WriteLine($"{Home.Name} {HomeGoals} - {AwayGoals} {Away.Name}");
    }

    public void ShootPenalties()
    {
        var homePenalties = GenerateRandomNumber.Generate();
        var awayPenalties = GenerateRandomNumber.Generate();
        if (homePenalties > awayPenalties)
        {
            HomeGoals = HomeGoals + 1;
        }
        else
        {
            AwayGoals = AwayGoals + 1;
        }
        
    }

    public Team GetWinner()
    {
        Team matchWinner;
        
        if (HomeGoals > AwayGoals)
        {
            matchWinner = Home;
        }
        else 
        {
            matchWinner = Away;
            
        }
        Console.WriteLine(matchWinner.Name);

        return matchWinner;
    }
}