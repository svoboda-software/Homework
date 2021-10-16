using Homework.Data.Repositories.FileRepository.Models;

namespace Homework.Data.Repositories.FileRepository
{
	public interface IFileRepository
	{
		GetPathResponse GetPath(GetPathRequest request);
	}
}