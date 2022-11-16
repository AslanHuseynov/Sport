using FirstLesson.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLesson.Matches
{
    public class BasketballMatch : Match<BasketballTeam>
    {
        public BasketballMatch(BasketballTeam home, BasketballTeam away) : base(home, away)
        {
        }

        public override void Start()
        {
            
            Start(50, 150);
        }


    }
}
