using Homework.Services.FileService.Models;

namespace Homework.Services.FileService
{
	public interface IFileService
	{
		GetLinesResponse GetLines(GetLinesRequest request);
		GetPathResponse GetPath(GetPathRequest request);
		GetPathsResponse GetPaths(GetPathsRequest request);
	}
}