using System;

namespace Scheduler.ConsoleClient
{
    class Program
    {
        private static ScheduleController scheduleCtrl = new ScheduleController();

        static void Main(string[] args)
        {
            scheduleCtrl.Load();

            while (true)
            {
                string key = scheduleCtrl.ShowCommandList();

                if (Enum.TryParse(key, out ESchedulerCommandType command))
                {
                    switch (command)
                    {
                        case ESchedulerCommandType.Add:
                            scheduleCtrl.AddSchedule();
                            break;

                        case ESchedulerCommandType.Edit:
                            scheduleCtrl.EditSchedule();
                            break;

                        case ESchedulerCommandType.Delete:
                            scheduleCtrl.DeleteSchedule();
                            break;

                        case ESchedulerCommandType.Sort:
                            scheduleCtrl.SortSchedule();
                            break;

                        case ESchedulerCommandType.Close:
                            return;

                        default:
                            // do nothing
                            break;
                    }
                }
            }
        }
    }
}