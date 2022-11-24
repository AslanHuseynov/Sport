namespace FirstLesson.Rules
{
    public class PlayoffBasketballRules : PlayoffRules
    {
        public override int MinGameQunatity => 3;
    }

    //public class PlayoffRange
    //{
    //    public int MinQuantity { get; set; }
    //    public int? MaxQuantity { get; set; }

    //    public PlayoffRange(int minQuantity)
    //    {
    //        MinQuantity = minQuantity;
    //    }
    //    public PlayoffRange(int minQuantity, int maxQuantity)
    //    {
    //        MinQuantity = minQuantity;
    //        MaxQuantity = maxQuantity;
    //    }
    //}
}
