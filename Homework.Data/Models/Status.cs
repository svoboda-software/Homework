using Homework.Shared.Enums;
using System.Collections.Generic;

namespace Homework.Data.Models
{
	public class Status
	{
		public Status(StatusTypeEnum StatusType, EventTypeEnum EventType, List<Sort> Sorts)
		{
			this.StatusType = StatusType;
			this.EventType = EventType;
			this.Sorts = Sorts;
		}

		public StatusTypeEnum StatusType { get; set; }
		public EventTypeEnum EventType { get; set; }
		public List<Sort> Sorts { get; set; }
	}
}