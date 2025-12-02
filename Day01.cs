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

        /*
            Part02
        */

        int stoppedAt = 50;
        int numTimesPassedZero = 0;

        foreach (string line in lines)
        {
            int delta = Convert.ToInt32(line[1..]);

            if (delta > 100)
            {
                numTimesPassedZero += delta / 100;
                delta %= 100;
            }

            delta *= line[0] == 'L' ? -1 : 1;

            int newStoppedPosition = stoppedAt + delta;

            if (newStoppedPosition < 0)
            {
                newStoppedPosition = 100 + newStoppedPosition;
            }

            newStoppedPosition %= 100;

            if (newStoppedPosition == 0 || (stoppedAt != 0 && (line[0] == 'L' && newStoppedPosition >= stoppedAt) || (line[0] == 'R' && newStoppedPosition <= stoppedAt)))
            {
                numTimesPassedZero += 1;
            }

            stoppedAt = newStoppedPosition;
        }

        DisplayResult(numTimesPassedZero, part: 2);
    }
}