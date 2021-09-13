using System;
using System.Collections.Generic;
using System.Linq;

namespace IntervalScheduling
{
        public class Interval
        {
            public int Start { get; set; }
            public int End { get; set; }
            public Interval(int start, int end)
            {
                Start = start;
                End = end;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                int numberOfIntervals = Convert.ToInt32(Console.ReadLine());
                List<Interval> allIntervals = new List<Interval>();

                for (int i = 0; i < numberOfIntervals; i++)
                {
                    var inputLine = Console.ReadLine();
                    string[] values = inputLine.Split(' ');

                    int start = Convert.ToInt32(values[0]);
                    int end = Convert.ToInt32(values[1]);
                    allIntervals.Add(new Interval(start, end));
                }

                List<Interval> sortedIntervals = allIntervals.OrderBy(i => i.End).ToList();
                List<Interval> notOverlaping = new List<Interval>();

                notOverlaping.Add(sortedIntervals[0]);
                sortedIntervals.RemoveAt(0);

                int notOverlappingCount = 0;
                for (int i = 0; i < sortedIntervals.Count; i++)
                {
                    if (sortedIntervals[i].Start >= notOverlaping[notOverlappingCount].End)
                    {
                        notOverlaping.Add(sortedIntervals[i]);
                        notOverlappingCount++;
                    }
                }

                Console.WriteLine(notOverlaping.Count);
            }
        }
}
