namespace Homework.Services.RecordService.Models
{
	public class Record
	{
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public string Email { get; set; }
		public string FavoriteColor { get; set; }
		public string DateOfBirth { get; set; }

		/// <summary>
		/// Overrides .ToString() to return a space-delimited string of record values.
		/// <summary>
		public override string ToString()
		{
			return string.Join(" ",
				// Use PadRight() to left-align the string columns for better readability.
				LastName?.Trim().PadRight(8),
				FirstName?.Trim().PadRight(9),
				Email?.Trim().PadRight(10),
				FavoriteColor?.Trim().PadRight(13),
				// Use PadLeft() to right-align the date column for better readability.
				DateOfBirth?.Trim().PadLeft(11));
		}
	}
}