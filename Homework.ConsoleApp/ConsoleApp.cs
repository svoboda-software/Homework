using System;

namespace Homework.ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Console.WriteLine();
				Console.WriteLine("-----------");
				Console.WriteLine("App Started");
				Console.WriteLine("-----------");
				Console.WriteLine();

				// var records = GetRecords();

				Console.WriteLine("   Sort 1 - Started.");

				// var sortFields = "by FavoriteColor, then by LastName";
				// var sortedRecords = SortRecords(records, sortFields);
				// DisplayRecords(sortedRecords);

				Console.WriteLine("   Sort 1 - Complete.");
				Console.WriteLine();
				Console.WriteLine("   Sort 2 - Started.");

				// var sortFields = "by DateOfBirth";
				// var sortedRecords = SortRecords(records, sortFields);
				// DisplayRecords(sortedRecords);

				Console.WriteLine("   Sort 2 - Complete.");
				Console.WriteLine();
				Console.WriteLine("   Sort 3 - Started.");

				// var sortFields = "by LastName desc";
				// var sortedRecords = SortRecords(records, sortFields);
				// DisplayRecords(sortedRecords);

				Console.WriteLine("   Sort 3 - Complete.");

				Console.WriteLine();
				Console.WriteLine("-------------");
				Console.WriteLine("App Completed");
				Console.WriteLine("-------------");
				Console.WriteLine();
			}
			catch (System.Exception ex)
			{
				throw ex;
			}
		}
	}
}