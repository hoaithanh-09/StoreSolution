using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities;

namespace Store.Data.Configurations
{
	public class DetailConfigurations : BaseConfigurations<Detail>
	{
		protected override void ConfigureMoreProperties(EntityTypeBuilder<Detail> builder)
		{
		}
	}
}
