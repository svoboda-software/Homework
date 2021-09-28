using Homework.Shared.Enums;
using Homework.Data.Models;
using Homework.Services.LogService.Implementation;
using Homework.Services.LogService.Models;
using System;
using System.Collections.Generic;

namespace Homework.Parser
{
	public class Parser
	{
		public void Parse()
		{
			try
			{
				// Inform the user the app has started.
				LogService.LogEntry(new LogEntryRequest()
				{
					LogEntry = new LogEntry(TaskTypeEnum.Application, EventTypeEnum.Started, null)
				});

				#region "Get Data"

				// Inform the user the data fetch has started.
				LogService.LogEntry(new LogEntryRequest()
				{
					LogEntry = new LogEntry(TaskTypeEnum.GetData, EventTypeEnum.Started, null)
				});

				// Get data records from files.
				// var records = GetRecords();

				// Inform the user the data fetch has completed.
				LogService.LogEntry(new LogEntryRequest()
				{
					LogEntry = new LogEntry(TaskTypeEnum.GetData, EventTypeEnum.Completed, null)
				});
				#endregion


				#region "Sort 1 - by FavoriteColor, then by LastName"

				var sort1 = new List<Sort>()
				{
					new Sort(RecordFieldTypeEnum.FavoriteColor),
					new Sort(RecordFieldTypeEnum.LastName)
				};

				// Inform the user Sort 1 has started.
				LogService.LogEntry(new LogEntryRequest()
				{
					LogEntry = new LogEntry(TaskTypeEnum.Sort, EventTypeEnum.Started, sort1)
				});

				// Perform Sort 1.
				// var sortedRecords = SortRecords(records, sort1);

				// Display Sort 1 results to user.
				// DisplayRecords(sortedRecords);

				// Inform the user Sort 1 has completed.
				LogService.LogEntry(new LogEntryRequest()
				{
					LogEntry = new LogEntry(TaskTypeEnum.Sort, EventTypeEnum.Completed, null)
				});
				#endregion


				#region "Sort 2 - by DateOfBirth"

				var sort2 = new List<Sort>()
				{
					new Sort(RecordFieldTypeEnum.DateOfBirth),
				};

				// Inform the user Sort 2 has started.
				LogService.LogEntry(new LogEntryRequest()
				{
					LogEntry = new LogEntry(TaskTypeEnum.Sort, EventTypeEnum.Started, sort2)
				});

				// Perform Sort 2.
				// var sortedRecords = SortRecords(records, sort2);

				// Display Sort 2 results to user.
				// DisplayRecords(sortedRecords);

				// Inform the user Sort 2 has completed.
				LogService.LogEntry(new LogEntryRequest()
				{
					LogEntry = new LogEntry(TaskTypeEnum.Sort, EventTypeEnum.Completed, null)
				});
				#endregion


				#region "Sort 3 - by LastName desc"

				var sort3 = new List<Sort>()
				{
					new Sort(RecordFieldTypeEnum.LastName, SortDirectionTypeEnum.Descending)
				};

				// Inform the user Sort 3 has started.
				LogService.LogEntry(new LogEntryRequest()
				{
					LogEntry = new LogEntry(TaskTypeEnum.Sort, EventTypeEnum.Started, sort3)
				});

				// Perform Sort 3.
				// var sortedRecords = SortRecords(records, sort3);

				// Display Sort 3 results to user.
				// DisplayRecords(sortedRecords);

				// Inform the user Sort 3 has completed.
				LogService.LogEntry(new LogEntryRequest()
				{
					LogEntry = new LogEntry(TaskTypeEnum.Sort, EventTypeEnum.Completed, null)
				});
				#endregion

				// Inform the user the app has completed.
				LogService.LogEntry(new LogEntryRequest()
				{
					LogEntry = new LogEntry(TaskTypeEnum.Application, EventTypeEnum.Completed, null)
				});
			}
			catch (System.Exception ex)
			{
				throw ex;
			}
		}
	}
}