using System;

namespace Homework.Data.Repositories.RecordRepository.Models
{
	public class Record
	{
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public string Email { get; set; }
		public string FavoriteColor { get; set; }
		public DateTime DateOfBirth { get; set; }
	}
}