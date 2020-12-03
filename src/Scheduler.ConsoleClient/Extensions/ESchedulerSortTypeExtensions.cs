using Scheduler.ConsoleClient.Enums;
using System;

namespace Scheduler.ConsoleClient.Extensions
{
    static class ESchedulerSortTypeExtensions
    {
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