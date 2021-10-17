using Homework.Data.Repositories.DelimiterRepository;
using Homework.Data.Repositories.DelimiterRepository.Implementation;
using Homework.Data.Repositories.FileRepository;
using Homework.Data.Repositories.FileRepository.Implementation;
using Homework.Data.Repositories.RecordRepository;
using Homework.Data.Repositories.RecordRepository.Implementation;
using Homework.Services.DelimiterService;
using Homework.Services.DelimiterService.Implementation;
using Homework.Services.FileService;
using Homework.Services.FileService.Implementation;
using Homework.Services.RecordService.Implementation;
using Homework.Services.RecordService;
using Homework.Services.RecordService.Models;
using Homework.Shared.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Homework.ConsoleApp
{
	public class Program
	{
		public static IServiceProvider serviceProvider { get; set; }

		#region "Public methods"

		public static void Main(string[] args)
		{
			var builder = Host.CreateDefaultBuilder().Build();

			serviceProvider = new ServiceCollection()
				.AddScoped<IDelimiterRepository, DelimiterRepository>()
				.AddScoped<IFileRepository, FileRepository>()
				.AddScoped<IRecordRepository, RecordRepository>()
				.AddSingleton<IDelimiterService, DelimiterService>()
				.AddSingleton<IFileService, FileService>()
				.AddSingleton<IRecordService, RecordService>()
				.BuildServiceProvider();

			Console.Clear();
			Console.WriteLine("- Query application started.");
			Console.WriteLine();

			// Query the records.
			QueryRecords();

			Console.WriteLine();
			Console.WriteLine("- Query application ended.");
			Console.WriteLine();
		}
		#endregion

		#region "Private methods"

		private static void Query(List<Sort> sorts)
		{
			// Show the query to the user.
			ShowQuery(sorts);

			var recordService = serviceProvider.GetService<IRecordService>();
			var sortedRecords = recordService.QueryRecords(new QueryRecordsRequest
			{
				Sorts = sorts.Select(s => new Sort
				{
					PropertyName = s.PropertyName,
					SortDirection = s.SortDirection
				}).ToList()
			})?.Records;

			ShowRecords(sortedRecords);
		}

		private static void QueryRecords()
		{
			Console.WriteLine("  - Querying records...");

			// Output 1: FavoriteColor ascending, then LastName ascending.
			Query(new List<Sort>
			{
				new Sort{ PropertyName = "FavoriteColor" },
				new Sort{ PropertyName = "LastName" }
			});

			// Output 2: DateOfBirth ascending.
			Query(new List<Sort> { new Sort { PropertyName = "DateOfBirth" } });

			// Output 3: LastName descending
			Query(new List<Sort>{ new Sort
			{
				PropertyName = "LastName",
				SortDirection = ListSortDirection.Descending
			}});
		}

		private static void ShowQuery(List<Sort> sorts)
		{
			Console.WriteLine();
			sorts?.ForEach(f =>
			{
				var sortBy = f == sorts.FirstOrDefault() ? "Sort by" : "Then by";
				Console.WriteLine($"    - {sortBy} {f.PropertyName} {f.SortDirection.ToString().ToLower()}");
			});
			Console.WriteLine();
		}

		private static void ShowRecords(List<Record> records)
		{
			// Show the column headers.
			Console.WriteLine($"      {records.First().ColumnHeaders()}");

			// Show separator lines between the column headers and the data.
			Console.WriteLine($@"      {string.Join(" ",
				string.Concat(Enumerable.Repeat("-", 8)),
				string.Concat(Enumerable.Repeat("-", 9)),
				string.Concat(Enumerable.Repeat("-", 12)),
				string.Concat(Enumerable.Repeat("-", 13)),
				string.Concat(Enumerable.Repeat("-", 11)))}");

			// Show the sorted list of records to the user.
			records?.ForEach(f => Console.WriteLine($"      {f.ToString()}"));
		}
		#endregion
	}
}