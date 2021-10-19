using Homework.Data.Repositories.DelimiterRepository.Models;
using System.Collections.Generic;
using System.Linq;

namespace Homework.Data.Repositories.DelimiterRepository.Implementation
{
	public class DelimiterRepository : IDelimiterRepository
	{
		// Define the data separating delimiters in the source files.
		private readonly List<Delimiter> delimiters = new List<Delimiter>
		{
			new Delimiter { Character = char.Parse(","), Name = "comma" },
			new Delimiter { Character = char.Parse("|"), Name = "pipe" },
			new Delimiter { Character = char.Parse(" "), Name = "space" }
		};

		public DelimiterRepository() { }

		#region Public methods
		public GetDelimiterResponse GetDelimiter(GetDelimiterRequest request)
		{
			var delimiter = GetDelimiter(request.DelimitedValues);

			return new GetDelimiterResponse
			{
				Success = !delimiter.Equals(char.Parse("")),
				Delimiter = delimiter
			};
		}

		public GetDelimitersResponse GetDelimiters(GetDelimitersRequest request)
		{
			return new GetDelimitersResponse
			{
				Success = delimiters != null,
				Delimiters = delimiters
			};
		}

		#endregion

		#region Private methods

		private char GetDelimiter(string delimitedValues)
		{
			var delimiter = delimiters
				.Where(w => delimitedValues.Contains(w.Character))
				.FirstOrDefault()
				.Character;
			return delimiter;
		}
		#endregion
	}
}