using Homework.Data.Repositories.FileRepository;
using FromRepo = Homework.Data.Repositories.FileRepository.Models;
using Homework.Services.DelimiterService;
using Homework.Services.DelimiterService.Models;
using Homework.Services.FileService.Models;
using Homework.Shared.Models;
using System.Collections.Generic;
using System.Linq;

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
			var delimeters = delimiterService.GetDelimiters(new GetDelimitersRequest())?.Delimiters;
			var files = delimeters?.Select(s => new File
			{
				Delimiter = s.Symbol,
				Path = repo.GetPath(new FromRepo.GetPathRequest{ DelimiterName = s.Name })?.Path
			})?.ToList();

			return new GetFilesResponse
			{
				Success = files != null,
				Files = files
			};
		}
	}
}