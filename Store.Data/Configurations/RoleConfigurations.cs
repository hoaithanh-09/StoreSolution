using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities;

namespace Store.Data.Configurations
{
	public class RoleConfigurations: BaseConfigurations<Role>
	{
		protected override void ConfigureMoreProperties(EntityTypeBuilder<Role> builder)
		{
		}
	}
}

