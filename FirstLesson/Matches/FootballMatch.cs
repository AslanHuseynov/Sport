using FirstLesson.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLesson.Matches
{
    public class FootballMatch : Match<FootballTeam>
    {
        public FootballMatch(FootballTeam home, FootballTeam away) : base(home, away)
        {
        }

        public override Match<FootballTeam> Reverse()
        {
            return new FootballMatch(Away, Home);
        }

        public override void Start()
        {
            Start(1, 10);
        }
    }
}
