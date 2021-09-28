using Homework.Shared.Enums;

namespace Homework.Data.Models
{
	public class Sort
	{
		public Sort(RecordFieldTypeEnum recordFieldType)
		{
			this.RecordFieldType = recordFieldType;
			this.SortDirectionType = SortDirectionTypeEnum.Ascending;
		}
		public Sort(RecordFieldTypeEnum recordFieldType, SortDirectionTypeEnum SortDirectionType)
		{
			this.RecordFieldType = recordFieldType;
			this.SortDirectionType = SortDirectionType;
		}
		public RecordFieldTypeEnum RecordFieldType { get; set; }
		public SortDirectionTypeEnum SortDirectionType { get; set; }
	}
}