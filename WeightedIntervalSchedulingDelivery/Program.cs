using System;

namespace WeightedIntervalSchedulingDelivery
{
    public class Job
    {
        public int Start { get; }
        public int End { get; }
        public int Weight { get; }

        public Job(int start, int end, int weight)
        {
            Start = start;
            End = end;
            Weight = weight;
        }
    }

    public class WeightedIntervalScheduling
    {

        public static int BinarySearch(Job[] jobs, int index)
        {
            int min = 0;
            int max = index - 1;

            while (min <= max)
            {
                int middle = (min + max) / 2;
                if (jobs[middle].End <= jobs[index].Start)
                {
                    if (jobs[middle + 1].End <= jobs[index].Start)
                        min = middle + 1;
                    else
                        return middle;
                }
                else
                    max = middle - 1;
            }

            return -1;
        }

        public static int MaxWeight(Job[] jobs)
        {
            Array.Sort(jobs, delegate (Job job1, Job job2)
            {
                return job1.End.CompareTo(job2.End);
            });

            int n = jobs.Length;
            int[] table = new int[n];
            table[0] = jobs[0].Weight;

            for (int i = 1; i < n; i++)
            {
                int addWeight = jobs[i].Weight;
                int nonOverlapping = BinarySearch(jobs, i);
                if (nonOverlapping != -1)
                    addWeight += table[nonOverlapping];

                table[i] = Math.Max(addWeight, table[i - 1]);
            }

            return table[n - 1];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfJobs = Convert.ToInt32(Console.ReadLine());
            Job[] jobs = new Job[numberOfJobs];

            for (int i = 0; i < numberOfJobs; i++)
            {
                var inputLine = Console.ReadLine();
                string[] values = inputLine.Split(' ');

                int start = Convert.ToInt32(values[0]);
                int end = Convert.ToInt32(values[1]);
                int weight = Convert.ToInt32(values[2]);

                jobs[i] = new Job(start, end, weight);
            }

            Console.WriteLine(WeightedIntervalScheduling.MaxWeight(jobs)); 
        }
    }
}
