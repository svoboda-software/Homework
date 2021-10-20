namespace Homework.Data.Repositories.FileRepository.Extensions
{
	public static class StringExtensions
	{
		#region Public methods

		/// <summary>
		/// Returns the path of the delimited text file.
		/// <summary>
		public static string ToPath(this string str)
		{
			// Use verbatim identifier @ to ignore the use of the forward slash '/' as an escape character.
			return $@"../Files/{str}-delimited.txt";
		}
		#endregion
	}
}