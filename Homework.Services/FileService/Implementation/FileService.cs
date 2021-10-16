using Homework.Data.Repositories.FileRepository;
using Homework.Services.DelimiterService;
using Homework.Services.DelimiterService.Models;
using Homework.Services.FileService.Models;
using Homework.Shared.Models;
using System.Collections.Generic;

namespace Homework.Services.FileService.Implementation
{
	public class FileService : IFileService
	{
		private IFileRepository repo { get; }
		private IDelimiterService delimiterService { get; set; }

		public FileService(IFileRepository repo, IDelimiterService delimiterService)
		{
			this.repo = repo;
			this.delimiterService = delimiterService;
		}

		public GetFilesResponse GetFiles(GetFilesRequest request)
		{
			var files = new List<File>();

			var delimeters = delimiterService.GetDelimiters(new GetDelimitersRequest())?.Delimiters;
			// TODO: Call the file repo to get the path from each delimiter.

			return new GetFilesResponse
			{
				Success = files != null,
				Files = files
			};
		}
	}
}