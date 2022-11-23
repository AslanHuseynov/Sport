namespace FirstLesson.Rules
{
    public class PlayoffBasketballRules : PlayoffRules
    {
        public override PlayoffRange GameQunatity => new PlayoffRange(4,7);
    }

    public class PlayoffRange
    {
        public int MinQuantity { get; set; }
        public int MaxQuantity { get; set; }

        public PlayoffRange(int minQuantity, int maxQuantity)
        {
            MinQuantity = minQuantity;
            MaxQuantity = maxQuantity;
        }
    }
}
