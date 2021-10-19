using Homework.Shared.Base;
using System.Collections.Generic;

namespace Homework.Services.FileService.Models
{
	public class GetPathsResponse : ResponseBase
	{
		public List<string> FilePaths { get; set; }
	}
}