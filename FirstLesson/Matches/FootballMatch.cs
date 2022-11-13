using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLesson.Matches
{
    public class FootballMatch : Match
    {
        public FootballMatch(Team home, Team away) : base(home, away)
        {
        }

        public override void Start()
        {
            Start(1, 10);
        }
    }
}
