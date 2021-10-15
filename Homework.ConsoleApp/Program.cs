using System;

namespace Homework.App
{
	public class Program
	{
		#region "Public methods"
		public static void Main(string[] args)
		{
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