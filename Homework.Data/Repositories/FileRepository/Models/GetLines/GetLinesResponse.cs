using Homework.Shared.Base;
using System.Collections.Generic;

namespace Homework.Data.Repositories.FileRepository.Models
{
	public class GetLinesResponse : ResponseBase
	{
		public List<string> Lines { get; set; }
	}
}