using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities;

namespace Store.Data.Configurations
{
	public class AddressConfigurations : BaseConfigurations<Address>
	{
		protected override void ConfigureMoreProperties(EntityTypeBuilder<Address> builder)
		{
		}
	}
}
