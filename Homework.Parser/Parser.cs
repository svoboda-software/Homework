using Homework.Shared.Enums;
using Homework.Data.Models;
using System;
using System.Collections.Generic;

namespace Homework.Parser
{
	public static class Parser
	{
		public static void Parse()
		{
			try
			{
				// Inform the user the app has started.
				DisplayStatus(new Status(StatusTypeEnum.Application, EventTypeEnum.Started, null));

				// Get data records from files.
				// var records = GetRecords();

				#region "Sort 1 - by FavoriteColor, then by LastName"

				var sort1 = new List<Sort>()
				{
					new Sort(FieldTypeEnum.FavoriteColor),
					new Sort(FieldTypeEnum.LastName)
				};

				DisplayStatus(new Status(StatusTypeEnum.Sort, EventTypeEnum.Started, sort1));

				// Perform Sort 1.
				// var sortedRecords = SortRecords(records, sort1);

				// Display Sort 1 results to user.
				// DisplayRecords(sortedRecords);

				DisplayStatus(new Status(StatusTypeEnum.Sort, EventTypeEnum.Completed, null));

				#endregion

				#region "Sort 2 - by DateOfBirth"

				var sort2 = new List<Sort>()
				{
					new Sort(FieldTypeEnum.DateOfBirth),
				};

				DisplayStatus(new Status(StatusTypeEnum.Sort, EventTypeEnum.Started, sort2));

				// Perform Sort 2.
				// var sortedRecords = SortRecords(records, sort2);

				// Display Sort 2 results to user.
				// DisplayRecords(sortedRecords);

				DisplayStatus(new Status(StatusTypeEnum.Sort, EventTypeEnum.Completed, null));
				#endregion

				#region "Sort 3 - by LastName desc"
				var sort3 = new List<Sort>()
				{
					new Sort(FieldTypeEnum.LastName, SortDirectionTypeEnum.Descending)
				};

				DisplayStatus(new Status(StatusTypeEnum.Sort, EventTypeEnum.Started, sort3));

				// Perform Sort 3.
				// var sortedRecords = SortRecords(records, sort3);

				// Display Sort 3 results to user.
				// DisplayRecords(sortedRecords);

				DisplayStatus(new Status(StatusTypeEnum.Sort, EventTypeEnum.Completed, null));
				#endregion

				// Inform the user the app has completed.
				DisplayStatus(new Status(StatusTypeEnum.Application, EventTypeEnum.Completed, null));
			}
			catch (System.Exception ex)
			{
				throw ex;
			}
		}

		private static void DisplayStatus(Status status)
		{
			if (status.StatusType == StatusTypeEnum.Application)
			{
				Console.WriteLine();
				Console.WriteLine("-------------");
				Console.WriteLine($"App { status.EventType }");
				Console.WriteLine("-------------");
			}
			else if (status.StatusType == StatusTypeEnum.Sort)
			{
				if (status.EventType == EventTypeEnum.Completed)
				{
					Console.WriteLine($"   Sort { status.EventType }");
				}
				if (status.Sorts != null)
				{
					foreach (var sort in status.Sorts)
					{
						Console.WriteLine($"   Sort by { sort.FieldType } { sort.SortDirectionType }.");
					}
				}
			}
			Console.WriteLine();
		}
	}
}