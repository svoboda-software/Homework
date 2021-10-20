using Homework.Data.Repositories.FileRepository.Extensions;
using Homework.Data.Repositories.FileRepository.Models;
using System.Collections.Generic;
using FromIO = System.IO;
using System.Linq;

namespace Homework.Data.Repositories.FileRepository.Implementation
{
	public class FileRepository : IFileRepository
	{
		public FileRepository() { }

		#region Public methods

		/// <summary>
		/// Returns a combined list of strings from a given list of text file paths.
		/// <summary>
		public GetLinesResponse GetLines(GetLinesRequest request)
		{
			var lines = new List<string>();

			request.Paths?
				.ForEach(f =>
					lines.AddRange(
						FromIO.File
							// Lazy load the file with ReadLines() instead of loading entire file into memory with ReadAllLines().
							.ReadLines(f)
							// Skip the column headers.
							.Skip(1)));

			return new GetLinesResponse
			{
				Success = lines != null,
				Lines = lines
			};
		}

		/// <summary>
		/// Returns a delimited data file path given the name of a delimitierZZZZZZZ.
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