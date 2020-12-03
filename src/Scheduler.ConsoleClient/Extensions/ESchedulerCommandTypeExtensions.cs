namespace Scheduler.ConsoleClient.Extensions
{
    public static class ESchedulerCommandTypeExtensions
    {
        public static string ToStr(this ESchedulerCommandType command)
        {
            switch (command)
            {
                case ESchedulerCommandType.Add: return "Press 1: ADD a schedule";
                case ESchedulerCommandType.Edit: return "Press 2: EDIT a schedule";
                case ESchedulerCommandType.Delete: return "Press 3: DELETE a schedule";
                case ESchedulerCommandType.Sort: return "Press 4: SORT the schedule list";
                case ESchedulerCommandType.Close: return "Press 5: CLOSE the Scheduler";
                default: return string.Empty;
            }
        }
    }
}