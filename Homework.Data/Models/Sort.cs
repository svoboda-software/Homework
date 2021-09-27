using Homework.Shared.Enums;

namespace Homework.Data.Models
{
	public class Sort
	{
		// Example of overloading.
		public Sort(FieldTypeEnum FieldType)
		{
			this.FieldType = FieldType;
			this.SortDirectionType = SortDirectionTypeEnum.Ascending;
		}

		public Sort(FieldTypeEnum FieldType, SortDirectionTypeEnum SortDirectionType)
		{
			this.FieldType = FieldType;
			this.SortDirectionType = SortDirectionType;
		}

		public FieldTypeEnum FieldType { get; set; }
		public SortDirectionTypeEnum SortDirectionType { get; set; }
	}
}