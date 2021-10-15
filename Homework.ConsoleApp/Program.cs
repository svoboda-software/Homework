using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Homework.App
{
	public class Program
	{
		public static IServiceProvider serviceProvider { get; set; }

		#region "Public methods"
		public static void Main(string[] args)
		{
			var builder = Host.CreateDefaultBuilder().Build();

			serviceProvider = new ServiceCollection().BuildServiceProvider();

			Console.Clear();
			Console.WriteLine("- Query application started.");
			Console.WriteLine();

			// Query the records.
			QueryRecords();

			Console.WriteLine("- Query application ended.");
			Console.WriteLine();
		}
		#endregion

		#region "Private methods"
		private static void QueryRecords()
		{
			Console.WriteLine("  - Querying records...");
		}
		#endregion
	}
}