using Homework.Shared.Base;
using System.Collections.Generic;

namespace Homework.Data.Repositories.FileRepository.Models
{
	public class GetPathsRequest : RequestBase
	{
		public List<string> DelimiterNames { get; set; }
	}
}