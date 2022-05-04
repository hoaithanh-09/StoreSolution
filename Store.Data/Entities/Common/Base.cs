using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Data.Entities.Common
{
	public class BaseEntity
	{
		[Key]
		//[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public DateTime DateCreated { get; set; } = DateTime.Now;
	}
}

