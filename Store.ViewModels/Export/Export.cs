using System;
using Store.Data.Enums;

namespace Store.ViewModels.Export
{
	public class Column<T>
	{
		public string Label { get; set; }

		public string Property { get; set; }

		public ColumnStyle Style { get; set; } = new ColumnStyle();

		public Func<T, string> Formatter { get; set; }
	}

	public class ColumnStyle
    {
		public AlignmentTypes Alignment { get; set; } = AlignmentTypes.Left;
	}
}

