using System;
namespace Store.Data.Entities.Common
{
	public class SoftDeletedEntity
	{
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; } = false;

        public DateTime DateUpdated { get; set; } = DateTime.Now;

        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
