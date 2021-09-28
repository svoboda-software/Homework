using Homework.Data.Models;
using Homework.Services.LogService.Models;
using Homework.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Homework.Services.LogService.Implementation
{
	//TODO:	Add interface inheritance. 	
	public static class LogService
	{
		public static LogEntryResponse LogEntry(LogEntryRequest request)
		{
			// Example of a null-conditional operator to get the child data object.
			var entry = request?.LogEntry;
			if (entry != null)
			{
				// Log the current task status to the screen.
				var timestamp = DateTime.UtcNow.ToString("HH:mm:ss.fff", CultureInfo.InvariantCulture);
				Console.WriteLine();
				Console.WriteLine(@$"{timestamp} {entry.TaskType} {entry.EventType}");
				entry.Sorts?.ForEach(f => Console.WriteLine($"                - Sort by {f.RecordFieldType} {f.SortDirectionType}"));
			}

			return new LogEntryResponse
			{
				Success = true
			};
		}
	}
}