namespace FirstLesson.Playoffs;

public abstract class PlayoffRound<TTeam> where TTeam : Team
{
    public List<Match<TTeam>> Rounds;
    public PenaltySeries PenaltySeries;
    
    public PlayoffRound(Match<TTeam> firstRound, int minGameQuantity)
    {
        Rounds = new List<Match<TTeam>>();
        var range = Enumerable.Range(1, minGameQuantity);
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
    }

    public abstract void Start();


    public abstract Team GetWinner();
}