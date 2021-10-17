using System;
using System.Globalization;

namespace Homework.Shared.Extensions
{
	public static class DateTimeExtensions
	{
		/// <summary>
		/// Returns a date string in the format specified by the business rules.
		/// <summary>
		public static string ToFormattedDateString(this DateTime dt)
		{
			return dt.ToString("M/d/yyyy", CultureInfo.InvariantCulture);
		}
	}
}