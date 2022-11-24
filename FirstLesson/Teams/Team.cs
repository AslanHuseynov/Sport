
using System.Diagnostics;

[DebuggerDisplay("{" + nameof(Name) + "}")]
public abstract class Team
{
    public string Name;
    public Team(string name)
    {
        Name = name;
    }
}
