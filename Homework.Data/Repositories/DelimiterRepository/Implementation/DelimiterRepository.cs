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

		/// <summary>
		/// Returns the delimiting character from a character-delimited string.
		/// <summary>
		public GetDelimiterResponse GetDelimiter(GetDelimiterRequest request)
		{
			var delimiter = GetDelimiter(request.DelimitedValues);

			return new GetDelimiterResponse
			{
				Success = delimiter != null,
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

		public SplitValuesResponse SplitValues(SplitValuesRequest request)
		{
			var delimitedValues = request.DelimitedValues;

			var values = delimitedValues.Split(
				GetDelimiter(delimitedValues).Character);

			return new SplitValuesResponse
			{
				Success = values != null,
				Values = values
			};
		}

		public SplitValuesListResponse SplitValuesList(SplitValuesListRequest request)
		{
			var valuesList = request.DelimitedValuesList
				// Split on any known delimiter in the string.
				.Select(s => s.Split(
					GetDelimiter(s).Character))
				.ToList();

			return new SplitValuesListResponse
			{
				Success = valuesList != null,
				ValuesList = valuesList
			};
		}
		#endregion

		#region Private methods

		private Delimiter GetDelimiter(string delimitedValues)
		{
			/// Returns the delimiting character from a character-delimited string.
			return delimiters
				.Where(w => delimitedValues.Contains(w.Character))
				.FirstOrDefault();
		}
		#endregion
	}
}