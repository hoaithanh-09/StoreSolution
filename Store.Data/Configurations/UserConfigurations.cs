using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities;

namespace Store.Data.Configurations
{
	public class UserConfigurations : BaseConfigurations<User>
	{
		protected override void ConfigureMoreProperties(EntityTypeBuilder<User> builder)
		{
		}
	}
}

