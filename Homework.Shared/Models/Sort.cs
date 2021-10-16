using System.ComponentModel;

namespace Homework.Shared.Models
{
	public class Sort
	{
		public Sort() { }
		public Sort(string propertyName, ListSortDirection sortDirection)
		{
			PropertyName = propertyName;
			SortDirection = sortDirection;
		}

		public string PropertyName { get; set; }
		public ListSortDirection SortDirection { get; set; }
	}
}