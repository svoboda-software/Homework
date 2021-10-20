namespace Homework.Services.RecordService.Extensions
{
	public static class RecordExtensions
	{
		#region Public methods

		/// <summary>
		/// Returns a parsed Record property name. 
		/// <summary>
		public static string ToParsedPropertyName(this string str)
		{
			// Handle mapping api routes to Record property names.
			switch (str?.ToLowerInvariant())
			{
				case "birthdate":
					str = "DateOfBirth";
					break;

				case "color":
					str = "FavoriteColor";
					break;

				case "name":
					str = "LastName";
					break;
			}

			return str;
		}
		#endregion
	}
}