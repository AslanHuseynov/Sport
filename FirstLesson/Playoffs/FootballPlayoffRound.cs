using FirstLesson.Teams;

namespace FirstLesson.Playoffs
{
    public class FootballPlayoffRound : PlayoffRound<FootballTeam>
    {
        const int MinGameQuantity = 1;
        private Match<FootballTeam> FirstRound;
        private Match<FootballTeam> SecondRound;
        public FootballPlayoffRound(Match<FootballTeam> firstRound) : base(firstRound, MinGameQuantity)
        {
            FirstRound = firstRound;
            SecondRound = Rounds.Skip(1).First();
        }


        public override void Start()
        {
            foreach (var item in Rounds)
            {
                item.Start();
            }


            var winner = GetWinnerWithoutPenalties();
            if (winner != null)
            {
                PrintResult();
                return;
            }

            var secondRound = Rounds.Skip(1).First();

            PenaltySeries = new PenaltySeries(secondRound.Home, secondRound.Away);
            PenaltySeries.Start(1, 6);
            PrintResult();
        }

        private void PrintResult()
        {
            var penalties = PenaltySeries != null ? PenaltySeries.GetScore() : string.Empty;
            Console.WriteLine($"{FirstRound.Away.Name} ({FirstRound.AwayScore}) {FirstRound.AwayScore + SecondRound.HomeScore} -" +
                              $" {FirstRound.HomeScore + SecondRound.AwayScore} ({FirstRound.HomeScore}) {FirstRound.Home.Name} " +
                              $"{penalties} [{GetWinner().Name}]");
        }

        private Team GetWinnerWithoutPenalties()
        {
            var sumOfGoalsFirst = FirstRound.HomeScore + SecondRound.AwayScore;
            var sumOfGoalsSecond = SecondRound.HomeScore + FirstRound.AwayScore;
            var winner = sumOfGoalsFirst > sumOfGoalsSecond ? FirstRound.Home :
                sumOfGoalsFirst < sumOfGoalsSecond ? FirstRound.Away : null;
            return winner;
        }

        public override Team GetWinner()
        {
            if (!Rounds.All(x => x.IsFinished))
                throw new InvalidOperationException("");

            var winner = GetWinnerWithoutPenalties();
            if (winner != null)
                return winner;

            return PenaltySeries.FirstGoals > PenaltySeries.SecondGoals
                ? PenaltySeries.TeamFirst
                : PenaltySeries.TeamSecond;
        }

    }
}
