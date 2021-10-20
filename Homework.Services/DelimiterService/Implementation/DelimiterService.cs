using Homework.Data.Repositories.DelimiterRepository;
using FromRepo = Homework.Data.Repositories.DelimiterRepository.Models;
using Homework.Services.DelimiterService.Models;
using Homework.Services.FileService;
using Homework.Services.FileService.Models;
using System.Collections.Generic;
using System.Linq;

namespace Homework.Services.DelimiterService.Implementation
{
	public class DelimiterService : IDelimiterService
	{
		private IDelimiterRepository repo { get; }
		private IFileService fileService { get; }

		public DelimiterService(IDelimiterRepository repo, IFileService fileService)
		{
			this.repo = repo;
			this.fileService = fileService;
		}

		#region Public methods

		/// <summary>
		/// Returns a list of value arrays from the data files.
		/// <summary>
		public GetDelimitedValuesResponse GetDelimitedValues(GetDelimitedValuesRequest request)
		{
			var filePaths = GetPaths(GetDelimiters());
			var fileLines = GetLines(filePaths);
			var values = SplitValues(fileLines);

			return new GetDelimitedValuesResponse
			{
				Success = values != null,
				Values = values
			};
		}

		/// <summary>
		/// Returns the delimiter from a given delimited value string.
		/// <summary>
		public GetDelimiterResponse GetDelimiter(GetDelimiterRequest request)
		{
			var delimiter = GetDelimiter(request.DelimitedValues);

			return new GetDelimiterResponse
			{
				Success = true, // !delimiter.Equals(char.Parse("")),
				Delimiter = delimiter
			};
		}

		/// <summary>
		/// Returns a list of valid delimiters used by business.
		/// <summary>
		public GetDelimitersResponse GetDelimiters(GetDelimitersRequest request)
		{
			var delimiters = GetDelimiters();

			return new GetDelimitersResponse
			{
				Success = delimiters != null,
				Delimiters = delimiters
			};
		}
		#endregion

		#region Private methods

		private char GetDelimiter(string values)
		{
			// Use the delimiter repository to get the delimiter from a delimited value string.
			return repo.GetDelimiter(
				new FromRepo.GetDelimiterRequest
				{
					DelimitedValues = values
				}).Delimiter;
		}

		private List<Delimiter> GetDelimiters()
		{
			// Use the delimiter repository to get the list of valid delimiters.
			return repo.GetDelimiters(
				new FromRepo.GetDelimitersRequest())?
					.Delimiters
					.Select(s => new Delimiter
					{
						Character = s.Character,
						Name = s.Name
					}).ToList();
		}

		private List<string> GetLines(List<string> paths)
		{
			// Use the file service to get the lines in the data files.
			return fileService.GetLines(
				new GetLinesRequest
				{
					FilePaths = paths
				}).FileLines;
		}

		private List<string> GetPaths(List<Delimiter> delimiters)
		{
			var delimiterNames = delimiters?
				.Select(s => s.Name).ToList();

			// Use the file service to get the paths of the data files.
			return fileService.GetPaths(
				new GetPathsRequest
				{
					DelimiterNames = delimiterNames
				}).FilePaths;
		}

		private List<string[]> SplitValues(List<string> delimitedValues)
		{
			// Use the delimiter repository to get the list of value arrays.
			return repo.SplitValues(
				new FromRepo.SplitValuesRequest
				{
					DelimitedValues = delimitedValues
				}).ValueArrays;
		}
		#endregion
	}
}