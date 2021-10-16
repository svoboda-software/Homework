using Homework.Shared.Base;
using Homework.Shared.Models;
using System.Collections.Generic;

namespace Homework.Services.FileService.Models
{
	public class GetFilesResponse : ResponseBase
	{
		public List<File> Files { get; set; }
	}
}