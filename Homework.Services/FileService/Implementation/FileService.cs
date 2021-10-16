using Homework.Data.Repositories.FileRepository;
using Homework.Services.FileService.Models;
using Homework.Shared.Models;
using System.Collections.Generic;

namespace Homework.Services.FileService.Implementation
{
	public class FileService : IFileService
	{
		private IFileRepository repo { get; }

		public FileService(IFileRepository repo)
		{
			this.repo = repo;
		}

		public GetFilesResponse GetFiles(GetFilesRequest request)
		{
			var files = new List<File>();

			// TODO: Use a delimiter service to return the list of delimiters used by business.
			// TODO: Call the file repo to get the path from each delimiter.

			return new GetFilesResponse
			{
				Success = files != null,
				Files = files
			};
		}
	}
}