using Homework.Shared.Base;

namespace Homework.Api.Models
{
	public class ApiResponse<T> where T : ResponseBase
	{
		public int StatusCode { get; set; }
		public T Data { get; set; }
	}
}