using Homework.Data.Repositories.DelimiterRepository.Models;
using Homework.Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace Homework.Data.Repositories.DelimiterRepository.Implementation
{
	public class DelimiterRepository : IDelimiterRepository
	{
		// Define the delimiting characters that separate data values in the source files.
		private readonly Dictionary<string, string> delimiters = new Dictionary<string, string>
		{
			{ "comma", "," },
			{ "pipe", "|" },
			{ "space", " "}
		};

		public DelimiterRepository() { }

		#region "Public methods"

		public GetDelimitersResponse GetDelimiters(GetDelimitersRequest request)
		{
			return new GetDelimitersResponse
			{
				Success = delimiters != null,
				Delimiters = delimiters.AsEnumerable()
				.Select(s => new Delimiter
				{
					Character = s.Value,
					Name = s.Key
				}).ToList()
			};
		}
		#endregion
	}
}