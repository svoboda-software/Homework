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
		/// Returns a delimited data file path given the delimiter name.
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