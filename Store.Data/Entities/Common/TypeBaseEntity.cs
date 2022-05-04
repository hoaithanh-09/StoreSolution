using System;

namespace Store.Data.Entities.Common
{
	public class TypeBaseEntity
	{
		public Guid Id { get; set; } = Guid.NewGuid();

		public string Description { get; set; }

		public DateTime DateCreated { get; set; } = DateTime.Now;
	}
}

