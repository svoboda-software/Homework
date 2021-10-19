using Homework.Data.Repositories.FileRepository.Models;

namespace Homework.Data.Repositories.FileRepository
{
	public interface IFileRepository
	{
		GetLinesResponse GetLines(GetLinesRequest request);
		GetPathsResponse GetPaths(GetPathsRequest request);
	}
}