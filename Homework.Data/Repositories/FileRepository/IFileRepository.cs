using Homework.Data.Repositories.FileRepository.Models;

namespace Homework.Data.Repositories.FileRepository
{
	public interface IFileRepository
	{
		GetLinesResponse GetLines(GetLinesRequest request);
		GetPathResponse GetPath(GetPathRequest request);
		GetPathsResponse GetPaths(GetPathsRequest request);
	}
}