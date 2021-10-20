using Homework.Shared.Base;
using System.Collections.Generic;

namespace Homework.Data.Repositories.FileRepository.Models
{
	public class GetPathsResponse : ResponseBase
	{
		public List<string> Paths { get; set; }
	}
}