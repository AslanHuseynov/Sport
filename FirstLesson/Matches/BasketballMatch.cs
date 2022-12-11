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

        public override Match<BasketballTeam> Reverse()
        {
            return new BasketballMatch(Away, Home);
        }

        public override void Start()
        {
            Start(50, 150);
        }
        public Team GetWinner()
        {
            if (HomeScore > AwayScore)
            {
                return Home;
            }

            else if (HomeScore < AwayScore)
            {
                return Away;
            }

            else
            {
                throw new Exception("blliiad");
            }
        }

        public string GetScore()
        {
            var homeFirstLetter = Home.Name.First().ToString();
            var awayFirstLetter = Away.Name.First().ToString();
            return $"({homeFirstLetter} {HomeScore} - {AwayScore} {awayFirstLetter})";
        }



    }
}
