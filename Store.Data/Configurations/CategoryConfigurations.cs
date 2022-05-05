using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities;

namespace Store.Data.Configurations
{
	public class CategoryConfigurations : BaseConfigurations<Category>
	{
		protected override void ConfigureMoreProperties(EntityTypeBuilder<Category> builder)
		{
		}
	}
}
