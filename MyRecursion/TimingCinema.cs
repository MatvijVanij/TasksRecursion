using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecursion
{
    public class TimingCinema
    {
        public static List<string> Name { get; set; }
        public static List<int> Duration { get; set; }
        public int ShowTime { get; set; }
        public List<int> CurrentDuration { get; set; }
        public List<TimingCinema> Next { get; set; }

        public TimingCinema(int showtime, List<int> currentDuration = null)
        {
            ShowTime = showtime;
            Next = new List<TimingCinema>();

            if (currentDuration is null)
            {
                CurrentDuration = new List<int>();
            }
            else
            {
                CurrentDuration = currentDuration;
            }
        }

        public void CreateScheduleBase()
        {
            int count = 0;
            foreach (int timeBase in Duration)
            {
                if (ShowTime >= count)
                {
                    count += timeBase;
                    List<int> tmp = new List<int>(CurrentDuration);
                    tmp.Add(timeBase);
                    TimingCinema timingCinema = new TimingCinema(ShowTime - timeBase, tmp);
                    Next.Add(timingCinema);
                }
            }
            ShowTime -= count;
            CreateSchedule();
        }

        public void CreateSchedule()
        {
            foreach (int time in Duration)
            {
                if (ShowTime >= time)
                {
                    List<int> tmp = new List<int>(CurrentDuration);
                    tmp.Add(time);
                    TimingCinema timingCinema = new TimingCinema(ShowTime - time, tmp);
                    Next.Add(timingCinema);
                    timingCinema.CreateSchedule();
                }
            }
        }

        public void WriteAllSessions()
        {
            if (Next.Count == 0)
            {
                foreach (int film in CurrentDuration)
                {
                    Console.Write(film + " " );
                }
                Console.WriteLine();
            }
            else
            {
                foreach (TimingCinema t in Next)
                {
                    t.WriteAllSessions();
                }
            }
        }

        public ReturnTiming FindTimeShowForCinema()
        {
            if (Next.Count == 0)
            {
                return new ReturnTiming(ShowTime, CurrentDuration);
            }
            else
            {
                List<ReturnTiming> returnModels = new List<ReturnTiming>();
                foreach (TimingCinema n in Next)
                {
                    returnModels.Add(n.FindTimeShowForCinema());
                }

                ReturnTiming min = returnModels[0];
                foreach (ReturnTiming r in returnModels)
                {
                    if (min.ShowTime > r.ShowTime)
                    {
                        min = r;
                    }
                    else if ((min.ShowTime == r.ShowTime) && (min.CurrentDuration.Count > r.CurrentDuration.Count))
                    {
                        min = r;
                    }
                }
                return min;
            }
        }
    }

    public class ReturnTiming
    {
        public int ShowTime { get; set; }
        public List<int> CurrentDuration { get; set; }
        public ReturnTiming(int showTime, List<int> currentDuration)
        {
            ShowTime = showTime;
            CurrentDuration = new List<int>(currentDuration);
        }
    }
}
