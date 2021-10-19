using Homework.Services.FileService.Models;

namespace Homework.Services.FileService
{
	public interface IFileService
	{
		public GetPathsResponse GetPaths(GetPathsRequest request);
	}
}