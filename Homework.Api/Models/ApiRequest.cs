using Homework.Shared.Base;

namespace Homework.Api.Models
{
	public class ApiRequest<T> where T : RequestBase
	{
		public T Arguments { get; set; }
	}
}