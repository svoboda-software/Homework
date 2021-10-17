using Homework.Data.Repositories.DelimiterRepository.Models;
using System.Collections.Generic;
using System.Linq;

namespace Homework.Data.Repositories.DelimiterRepository.Implementation
{
	public class DelimiterRepository : IDelimiterRepository
	{
		// Define the delimiting characters that separate data values in the source files.
		private readonly Dictionary<string, string> Delimiters = new Dictionary<string, string>
		{
			{ "comma", "," },
			{ "pipe", "|" },
			{ "space", " "}
		};

		public DelimiterRepository() { }

		#region "Public methods"

		public GetDelimitersResponse GetDelimiters(GetDelimitersRequest request)
		{
			var delimiters = Delimiters.AsEnumerable()
				.Select(s => new Delimiter
				{
					Symbol = s.Value,
					Name = s.Key
				}).ToList();

			return new GetDelimitersResponse
			{
				Success = delimiters != null,
				Delimiters = delimiters
			};
		}
		#endregion
	}
}