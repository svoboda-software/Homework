using Homework.Shared.Base;
using System.Collections.Generic;

namespace Homework.Services.FileService.Models
{
	public class GetPathsRequest : RequestBase
	{
		public List<string> DelimiterNames { get; set; }
	}
}