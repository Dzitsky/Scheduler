using System;

namespace Scheduler.Application
{
	[Serializable]
	public class ScheduleInfo
	{
		public int id;
		public ScheduleData data;

		public ScheduleInfo(int id, ScheduleData data)
		{
			this.id = id;
			this.data = data;
		}
	}
}