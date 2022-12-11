using System.IO;
using System.Text.RegularExpressions;

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

    public static TMatch GenerateMatch<TMatch, TTeam>(List<TTeam> teams) where TTeam : Team
    {
        var home = GetOpponent(teams);
        var away = GetOpponent(teams);
        return (TMatch)Activator.CreateInstance(typeof(TMatch), new object[] { home, away });
        //return new Match(home, away);
    }
}