using System;

namespace Scheduler
{
	[Serializable]
	struct ScheduleData
	{
		public string title;
		public DateTime dateTime;
		public ESchedulePriority priority;

		public ScheduleData(string title, ESchedulePriority priority, DateTime dateTime)
		{
			this.title = title;
			this.priority = priority;
			this.dateTime = dateTime;
		}
	}
}
