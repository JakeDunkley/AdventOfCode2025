namespace AdventOfCode2025;

public abstract class IDay
{
    public abstract void Run();

    public void DisplayResult(object answer, int? part = null)
    {
        Console.WriteLine($"{this.GetType().Name + (part != null ? $" Part{part:00}" : "")} puzzle answer: {answer}");
    }

    public static string PathOf(string fileName)
    {
        return $"C:\\MyProjects\\AdventOfCode2025\\inputs\\{fileName}";
    }
}