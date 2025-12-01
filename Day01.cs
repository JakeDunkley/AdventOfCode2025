namespace AdventOfCode2025;

public class Day01 : IDay
{
    public override void Run()
    {
        string[] lines = File.ReadAllLines(PathOf("input_Day01.txt"));

        int currentRot = 50;
        int numTimesAtZero = 0;

        foreach (string line in lines)
        {
            if (line[0] == 'L')
            {
                currentRot -= Convert.ToInt32(line[1..]);
            }

            else
            {
                currentRot += Convert.ToInt32(line[1..]);
            }

            currentRot %= 100;

            if (currentRot == 0)
            {
                numTimesAtZero += 1;
            }
        }

        DisplayResult(numTimesAtZero, part: 1);
    }
}