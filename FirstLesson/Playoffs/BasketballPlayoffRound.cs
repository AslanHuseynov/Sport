using FirstLesson.Matches;
using FirstLesson.Rules;
using FirstLesson.Teams;

namespace FirstLesson.Playoffs
{
    public class BasketballPlayoffRound : PlayoffRound<BasketballTeam>
    {
        const int MinGameQuantity = 3;
        public BasketballPlayoffRound(Match<BasketballTeam> firstRound) : base(firstRound, MinGameQuantity)
        {

        }

        private Tuple<BasketballTeam, BasketballTeam> GetTeams()
        {
            var firstTeam = Rounds.First().Home;
            var secondTeam = Rounds.First().Away;

            return Tuple.Create(firstTeam, secondTeam);
        }

        private Tuple<int, int> GetWinnersQuantity()
        {
            var teams = GetTeams();
            var winners = Rounds.Select(x => ((BasketballMatch)x).GetWinner());
            var firstTeamVictoryQuantity = winners.Count(x => x.Name == teams.Item1.Name);
            var secondTeamVictoryQuantity = winners.Count(x => x.Name == teams.Item2.Name);
            return Tuple.Create(firstTeamVictoryQuantity, secondTeamVictoryQuantity);
        }


        public override void Start()
        {
            foreach (var item in Rounds)
            {
                item.Start();
            }

            var teams = GetTeams();
            var firstTeam = teams.Item1;
            var secondTeam = teams.Item2;
            var score = GetWinnersQuantity();
            var firstTeamVictoryQuantity = score.Item1;
            var secondTeamVictoryQuantity = score.Item2;

            while (firstTeamVictoryQuantity != 4 && secondTeamVictoryQuantity != 4)
            {

                var newMatch = new BasketballMatch(firstTeam, secondTeam);
                newMatch.Start();
                var winner = newMatch.GetWinner();
                if (winner.Name == firstTeam.Name)
                    firstTeamVictoryQuantity++;
                else
                    secondTeamVictoryQuantity++;
                Rounds.Add(newMatch);
                
            }
            

        }

        public override Team GetWinner()
        {
            throw new NotImplementedException();
        }

        public void PrintResult()
        {
            //Home 4 - 2 Away (88- 40)(77-4)
            var list = new List<string>();
            foreach (var item in Rounds)
            {
                var score = ((BasketballMatch)item).GetScore();
                list.Add(score);
                //Console.WriteLine(((BasketballMatch)item).GetScore());
            }
            var joinText = string.Join(string.Empty, list);
            var totalScore = GetScore();

            
            Console.WriteLine($"{totalScore} {joinText}");
        }
        public string GetScore()
        {
            var teams = GetTeams();
            var homeName = teams.Item1.Name;
            var awayName = teams.Item2.Name;
            var score = GetWinnersQuantity();
            var totalScore = $"({homeName} {score.Item1} - {score.Item2} {awayName})";
            return totalScore;
        }
    }
}
