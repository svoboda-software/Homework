using Homework.Services.FileService.Models;

namespace Homework.Services.FileService
{
	public interface IFileService
	{
		GetLinesResponse GetLines(GetLinesRequest request);
		GetPathsResponse GetPaths(GetPathsRequest request);
	}
}