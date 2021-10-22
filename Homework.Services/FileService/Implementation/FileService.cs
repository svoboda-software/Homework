using Homework.Data.Repositories.FileRepository;
using FromRepo = Homework.Data.Repositories.FileRepository.Models;
using Homework.Services.FileService.Models;

namespace Homework.Services.FileService.Implementation
{
	public class FileService : IFileService
	{
		private IFileRepository repo { get; }

		public FileService(IFileRepository repo)
		{
			this.repo = repo;
		}

		#region Public methods

		/// <summary>
		/// Returns a combined list of strings from a given list of text file paths.
		/// <summary>
		public GetLinesResponse GetLines(GetLinesRequest request)
		{
			var lines = repo.GetLines(
				new FromRepo.GetLinesRequest
				{
					Paths = request?.FilePaths
				})?.Lines;

			return new GetLinesResponse
			{
				Success = lines != null,
				FileLines = lines
			};
		}

		/// <summary>
		/// Returns a delimited data file path given a delimiter name.
		/// <summary>
		public GetPathResponse GetPath(GetPathRequest request)
		{
			var path = repo.GetPath(
				new FromRepo.GetPathRequest
				{
					DelimiterName = request?.DelimiterName
				})?.Path;

			return new GetPathResponse
			{
				Success = path != null,
				FilePath = path
			};
		}

		/// <summary>
		/// Returns a list of delimited data file paths given the delimiter names.
		/// <summary>
		public GetPathsResponse GetPaths(GetPathsRequest request)
		{
			var paths = repo.GetPaths(
				new FromRepo.GetPathsRequest
				{
					DelimiterNames = request?.DelimiterNames
				})?.Paths;

			return new GetPathsResponse
			{
				Success = paths != null,
				FilePaths = paths
			};
		}
		#endregion
	}
}