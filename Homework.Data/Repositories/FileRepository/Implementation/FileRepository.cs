using Homework.Data.Repositories.FileRepository.Models;

namespace Homework.Data.Repositories.FileRepository.Implementation
{
	public class FileRepository : IFileRepository
	{
		public FileRepository() { }

		#region "Public methods"

		public GetPathResponse GetPath(GetPathRequest request)
		{
			// TODO: Get the file path from a given delimiter.
			string path = string.Empty;

			return new GetPathResponse
			{
				Path = path,
				Success = path != null
			};
		}
		#endregion
	}
}