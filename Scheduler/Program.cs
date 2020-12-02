using System;

namespace Scheduler
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

        if (Enum.TryParse(key, out ESchedulerCommand command))
        {
          switch (command)
          {
            case ESchedulerCommand.Add:
              scheduleCtrl.AddSchedule();
              break;

            case ESchedulerCommand.Edit:
              scheduleCtrl.EditSchedule();
              break;

            case ESchedulerCommand.Delete:
              scheduleCtrl.DeleteSchedule();
              break;
            
            case ESchedulerCommand.Sort:
              scheduleCtrl.SortSchedule();
              break;

            case ESchedulerCommand.Close:
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
