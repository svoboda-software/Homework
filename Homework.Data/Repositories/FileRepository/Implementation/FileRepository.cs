using Homework.Data.Repositories.FileRepository.Models;

namespace Homework.Data.Repositories.FileRepository.Implementation
{
	public class FileRepository : IFileRepository
	{
		public FileRepository() { }

		#region "Public methods"

		public GetPathResponse GetPath(GetPathRequest request)
		{
			// Use verbatim identifier @ to ignore the use of forward slash '/' as an escape character.
			var path = $@"../Files/{request?.DelimiterName}-delimited.txt";

			return new GetPathResponse
			{
				Success = path != null,
				Path = path
			};
		}
		#endregion
	}
}