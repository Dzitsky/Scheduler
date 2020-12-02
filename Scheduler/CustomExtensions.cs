using System;

namespace Scheduler
{
  static class CustomExtensions
  {
    public static string ToStr(this ESchedulePriority priority)
    {
      switch (priority)
      {
        case ESchedulePriority.Normal: return "Normal";
        case ESchedulePriority.Middle: return "Middle";
        case ESchedulePriority.High: return "High";
        default: return string.Empty;
      }
    }

    public static string ToStr(this ESchedulerCommand command)
    {
      switch (command)
      {
        case ESchedulerCommand.Add: return "Press 1: ADD a schedule";
        case ESchedulerCommand.Edit: return "Press 2: EDIT a schedule";
        case ESchedulerCommand.Delete: return "Press 3: DELETE a schedule";
        case ESchedulerCommand.Sort: return "Press 4: SORT the schedule list";
        case ESchedulerCommand.Close: return "Press 5: CLOSE the Scheduler";
        default: return string.Empty;
      }
    }

    public static string ToStr(this ESchedulerSortType sortType)
    {
      switch (sortType)
      {
        case ESchedulerSortType.SortById: return "Press 1: Sort by ID";
        case ESchedulerSortType.SortByTitle: return "Press 2: Sort by TITLE";
        case ESchedulerSortType.SortByPriority: return "Press 3: Sort by PRIORITY";
        case ESchedulerSortType.SortByDateTime: return "Press 4: Sort by DATE";
        default: return string.Empty;
      }
    }
  }
}