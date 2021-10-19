using Homework.Data.Repositories.FileRepository.Extensions;
using Homework.Data.Repositories.FileRepository.Models;
using System.Linq;

namespace Homework.Data.Repositories.FileRepository.Implementation
{
	public class FileRepository : IFileRepository
	{
		public FileRepository() { }

		#region Public methods
		/// <summary>
		/// Returns a delimited data file path given the delimiter name.
		/// <summary>
		public GetPathsResponse GetPaths(GetPathsRequest request)
		{
			var paths = request.DelimiterNames
				?.Select(s => s.ToPath())
				?.ToList();

			return new GetPathsResponse
			{
				Success = paths != null,
				Paths = paths
			};
		}
		#endregion
	}
}