using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Homework.Api.Models;
using Homework.Services.RecordService;
using Homework.Services.RecordService.Models;

namespace Homework.Api.Controllers
{
	[ApiController]
	public class RecordsController : Controller
	{
		private readonly IRecordService recordService;

		public RecordsController(IRecordService recordService)
		{
			this.recordService = recordService;
		}

		[Route("[controller]")]
		[HttpPost]
		public ApiResponse<AddRecordResponse> AddRecord(ApiRequest<AddRecordRequest> request)
		{
			var response = new ApiResponse<AddRecordResponse>();
			response.Data = recordService.AddRecord(request.Arguments);
			response.StatusCode = StatusCodes.Status200OK;
			return response;
		}

		[Route("[controller]/{propertyName?}")]
		[HttpGet]
		public ApiResponse<QueryPropertyResponse> QueryRecords(string propertyName)
		{
			var response = new ApiResponse<QueryPropertyResponse>();
			response.Data = recordService.QueryProperty(new QueryPropertyRequest { PropertyName = propertyName });
			response.StatusCode = StatusCodes.Status200OK;

			return response;
		}
	}
}