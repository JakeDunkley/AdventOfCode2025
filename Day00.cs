namespace AdventOfCode2025;

public class Day00 : IDay
{
    public override void Run()
    {
        List<int> leftLocationIds = [];
        List<int> rightLocationIds = [];

        string[] lines = File.ReadAllLines(PathOf("input_Day00.txt"));

        foreach (string line in lines)
        {
            string[] split = line.Split(' ', options: StringSplitOptions.RemoveEmptyEntries);

            leftLocationIds.Add(Convert.ToInt32(split[0]));
            rightLocationIds.Add(Convert.ToInt32(split[1]));
        }

        leftLocationIds.Sort();
        rightLocationIds.Sort();

        List<int> diffs = [];

        for (int i = 0; i < leftLocationIds.Count; i++)
        {
            diffs.Add(Math.Abs(leftLocationIds[i] - rightLocationIds[i]));
        }

        DisplayResult(diffs.Sum(), part: 1);

        /*
            Part02
        */

        Dictionary<int, int> similarityScores = leftLocationIds
            .GroupBy(lid => lid)
            .ToDictionary(g => g.Key, g => rightLocationIds.Where(rlid => rlid == g.Key).Count());
        
        int sum = similarityScores
            .Select(ss => ss.Key * ss.Value)
            .Sum();
        
        DisplayResult(sum, part: 2);
    }
}