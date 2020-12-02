using System;

namespace Scheduler
{
  class ScheduleController
  {
    private ScheduleManager scheduleMng = new ScheduleManager();
    public ScheduleController()
    {
    }

    public void Load()
    {
      scheduleMng.Load();
    }

    public string ShowCommandList()
    {
      ShowHeader();

      Console.WriteLine("");
      Console.WriteLine("Select a command for the Scheduler:");
      Console.WriteLine("");

      foreach (ESchedulerCommand command in Enum.GetValues(typeof(ESchedulerCommand)))
      {
        Console.WriteLine(command.ToStr());
      }

      Console.WriteLine("");
      Console.Write("Input a command - ");

      return Console.ReadLine();
    }

    public void AddSchedule()
    {
      ShowHeader();

      Console.WriteLine("");
      Console.WriteLine("ADD a new schedule:");
      Console.WriteLine("");

      ScheduleData schedule = InputScheduleData();
      scheduleMng.AddSchedule(schedule);
    }

    public void EditSchedule()
    {
      ShowHeader();

      Console.WriteLine("");
      Console.WriteLine("EDIT the schedule:");
      Console.WriteLine("");

      Console.Write("Input ID - ");

      string key = Console.ReadLine();

      if (Int32.TryParse(key, out int scheduleId))
      {
        if (scheduleMng.HasScheduleById(scheduleId))
        {
          Console.WriteLine("");
          Console.WriteLine("Input new data:");
          Console.WriteLine("");

          ScheduleData schedule = InputScheduleData();
          scheduleMng.EditSchedule(scheduleId, schedule);
        }
      }
    }

    public void DeleteSchedule()
    {
      ShowHeader();

      Console.WriteLine("");
      Console.WriteLine("DELETE the schedule:");
      Console.WriteLine("");

      Console.Write("Input ID - ");

      string key = Console.ReadLine();

      if (Int32.TryParse(key, out int scheduleId))
      {
        scheduleMng.DeleteSchedule(scheduleId);
      }
    }

    private string ShowSortTypeList()
    {
      ShowHeader();

      Console.WriteLine("");
      Console.WriteLine("Select of sort type:");
      Console.WriteLine("");

      foreach (ESchedulerSortType sortType in Enum.GetValues(typeof(ESchedulerSortType)))
      {
        Console.WriteLine(sortType.ToStr());
      }

      Console.WriteLine("");
      Console.Write("Input a sort type - ");

      return Console.ReadLine();
    }

    public void SortSchedule()
    {
      string key = ShowSortTypeList();

      if (Enum.TryParse(key, out ESchedulerSortType sortType))
      {
        switch (sortType)
        {
          case ESchedulerSortType.SortById:
            scheduleMng.SortScheduleById();
            break;

          case ESchedulerSortType.SortByTitle:
            scheduleMng.SortScheduleByTitle();
            break;

          case ESchedulerSortType.SortByPriority:
            scheduleMng.SortScheduleByPriority();
            break;

          case ESchedulerSortType.SortByDateTime:
            scheduleMng.SortScheduleByDateTime();
            break;

          default:
            //dp nothing
            break;
        }
      }
    }

    private void ShowHeader()
    {
      Console.Clear();

      Console.WriteLine("Console Scheduler 1.0 :) ");
      Console.WriteLine("----------------------------------------------------------");
      Console.WriteLine("");

      scheduleMng.ShowData();

      Console.WriteLine("");
      Console.WriteLine("----------------------------------------------------------");
    }

    private ScheduleData InputScheduleData()
    {
      Console.Write("Input \"Title\" - ");

      string title = Console.ReadLine();

      Console.WriteLine("");
      Console.Write("Priority: ");

      foreach (ESchedulePriority priorityValue in Enum.GetValues(typeof(ESchedulePriority)))
      {
        Console.Write((int)priorityValue + " [" + priorityValue.ToStr() + "]" + " ");
      }

      Console.Write(")\n");

      Console.Write("Input \"Priority key\" - ");

      ESchedulePriority priority = GetPriority(Console.ReadLine());

      Console.WriteLine("");
      Console.Write("Date format [dd.mm.yyyy]\n");

      Console.Write("Input \"Date\" - ");

      DateTime dateTime = GetDateTime(Console.ReadLine());

      return new ScheduleData(title, priority, dateTime);
    }

    private ESchedulePriority GetPriority(string key)
    {
      if (Enum.TryParse(key, out ESchedulePriority priority))
      {
        return priority;
      }
      else
      {
        return ESchedulePriority.Normal;
      }
    }

    private DateTime GetDateTime(string key)
    {
      if (DateTime.TryParse(key, out DateTime dateTime))
      {
        return dateTime;
      }
      else
      {
        return DateTime.Now;
      }
    }
  }
}
