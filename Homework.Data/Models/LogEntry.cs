using Homework.Shared.Enums;
using System.Collections.Generic;

namespace Homework.Data.Models
{
	public class LogEntry
	{
		public LogEntry(TaskTypeEnum TaskType, EventTypeEnum EventType, List<Sort> Sorts)
		{
			this.TaskType = TaskType;
			this.EventType = EventType;
			this.Sorts = Sorts;
		}
		public TaskTypeEnum TaskType { get; set; }
		public EventTypeEnum EventType { get; set; }
		public List<Sort> Sorts { get; set; }
	}
}