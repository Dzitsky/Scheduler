using System;
using Scheduler.Application.Enums;

namespace Scheduler.Application
{
	[Serializable]
	public struct ScheduleData
	{
		public string title;
		public DateTime dateTime;
		public PriorityType priority;

		public ScheduleData(string title, PriorityType priority, DateTime dateTime)
		{
			this.title = title;
			this.priority = priority;
			this.dateTime = dateTime;
		}
	}
}