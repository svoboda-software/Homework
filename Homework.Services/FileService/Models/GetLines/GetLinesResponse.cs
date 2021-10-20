using Homework.Shared.Base;
using System.Collections.Generic;

namespace Homework.Services.FileService.Models
{
	public class GetLinesResponse : ResponseBase
	{
		public List<string> FileLines { get; set; }
	}
}