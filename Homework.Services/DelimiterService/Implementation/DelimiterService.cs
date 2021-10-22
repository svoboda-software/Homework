using Homework.Data.Repositories.DelimiterRepository;
using FromRepo = Homework.Data.Repositories.DelimiterRepository.Models;
using Homework.Services.DelimiterService.Models;
using Homework.Services.FileService;
using FromFileService = Homework.Services.FileService.Models;
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
		/// Returns a list of value arrays from all delimited data files.
		/// <summary>
		public GetValuesFromAllDelimitersResponse GetValuesFromAllDelimiters(GetValuesFromAllDelimitersRequest request)
		{
			var filePaths = GetDelimiters().Select(s => s.FilePath).ToList();
			var fileLines = GetLines(filePaths);
			var valuesList = SplitValuesList(fileLines);

			return new GetValuesFromAllDelimitersResponse
			{
				Success = valuesList != null,
				ValuesList = valuesList
			};
		}

		/// <summary>
		/// Returns a value array from a given character-delimited string.
		/// <summary>
		public GetValuesFromDelimiterResponse GetValuesFromDelimiter(GetValuesFromDelimiterRequest request)
		{
			var values = SplitValues(request.DelimitedValues);

			return new GetValuesFromDelimiterResponse
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
				Success = delimiter != null,
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

		private Delimiter GetDelimiter(string values)
		{
			// Use the delimiter repository to get the delimiter from a delimited value string.
			var delimiter = repo.GetDelimiter(
				new FromRepo.GetDelimiterRequest { DelimitedValues = values })
				.Delimiter;

			return new Delimiter
			{
				Character = delimiter.Character,
				FilePath = GetPath(delimiter.Name),
				Name = delimiter.Name
			};
		}

		private List<Delimiter> GetDelimiters()
		{
			// Use the delimiter repository to get the list of valid delimiters.
			var delimiters = repo.GetDelimiters(
				new FromRepo.GetDelimitersRequest())?
					.Delimiters
					.Select(s => new Delimiter
					{
						Character = s.Character,
						FilePath = s.FilePath,
						Name = s.Name
					}).ToList();

			return delimiters.Select(s => new Delimiter
			{
				Character = s.Character,
				FilePath = GetPath(s.Name),
				Name = s.Name
			}).ToList();
		}

		private List<string> GetLines(List<string> paths)
		{
			// Use the file service to get the lines in the data files.
			return fileService.GetLines(
				new FromFileService.GetLinesRequest
				{
					FilePaths = paths
				}).FileLines;
		}
		private string GetPath(string delimiterName)
		{
			// Use the file service to get the path to the character-delimited data file.
			return fileService.GetPath(
				new FromFileService.GetPathRequest
				{
					DelimiterName = delimiterName
				}).FilePath;
		}

		private List<string> GetPaths(List<string> delimiterNames)
		{
			// Use the file service to get the path to the character-delimited data file.
			return fileService.GetPaths(
				new FromFileService.GetPathsRequest
				{
					DelimiterNames = delimiterNames
				}).FilePaths;
		}

		private string[] SplitValues(string delimitedValues)
		{
			// Use the delimiter repository to get the list of value arrays.
			return repo.SplitValues(
				new FromRepo.SplitValuesRequest
				{
					DelimitedValues = delimitedValues
				}).Values;
		}

		private List<string[]> SplitValuesList(List<string> delimitedValuesList)
		{
			// Use the delimiter repository to get the list of value arrays.
			return repo.SplitValuesList(
				new FromRepo.SplitValuesListRequest
				{
					DelimitedValuesList = delimitedValuesList
				}).ValuesList;
		}
		#endregion
	}
}