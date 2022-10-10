namespace FirstLesson;

public static class GenerateRandomNumber
{
    public static Random Random = new Random();
    public static int Generate()
    {
        var randomNumber = Random.Next(1, 6);
        return randomNumber;
    }
    
}