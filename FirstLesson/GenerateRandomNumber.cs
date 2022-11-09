namespace FirstLesson;

public static class GenerateRandomNumber
{
    private static readonly Random Random = new Random();
    public static int Generate(int start, int end)
    {
        var randomNumber = Random.Next(start, end);
        return randomNumber;
    }
    
}