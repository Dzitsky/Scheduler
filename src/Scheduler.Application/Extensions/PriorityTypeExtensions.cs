using Scheduler.Application.Enums;

namespace Scheduler.Application.Extensions
{
    public static class PriorityTypeExtensions
    {
        public static string ToStr(this PriorityType priority)
        {
            switch (priority)
            {
                case PriorityType.Normal: return "Normal";
                case PriorityType.Middle: return "Middle";
                case PriorityType.High: return "High";
                default: return string.Empty;
            };
        }
    }
}