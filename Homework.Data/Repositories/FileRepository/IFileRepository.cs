using Homework.Data.Repositories.FileRepository.Models;

namespace Homework.Data.Repositories.FileRepository
{
	public interface IFileRepository
	{
		GetPathsResponse GetPaths(GetPathsRequest request);
	}
}