using System.IO;

namespace FirstLesson;

public static class GenerateRandomMatch
{
    private static TTeam GetOpponent<TTeam>(IList<TTeam> teams) where TTeam : Team
    {
        var index = GenerateRandomNumber.Generate(0, teams.Count);
        var randomElement = teams[index];
        teams.RemoveAt(index);
        return randomElement;
    }

    public static Match GenerateMatch(List<Team> teams)
    {
        var home = GetOpponent(teams);
        var away = GetOpponent(teams);
        return new Match(home, away);
    }
}