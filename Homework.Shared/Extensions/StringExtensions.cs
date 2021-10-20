using System;
using System.Globalization;

namespace Homework.Shared.Extensions
{
	public static class StringExtensions
	{
		#region Public methods

		/// <summary>
		/// Returns a parsed DateTime.
		/// <summary>
		public static DateTime ToParsedDate(this string str)
		{
			// Handle invalid date values.
			DateTime result = DateTime.TryParse(str, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.AdjustToUniversal, out var date)
				? date : DateTime.MinValue;

			return result;
		}
		#endregion
	}
}