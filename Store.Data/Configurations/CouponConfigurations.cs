using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities;

namespace Store.Data.Configurations
{
	public class CouponConfigurations : BaseConfigurations<Coupon>
	{
		protected override void ConfigureMoreProperties(EntityTypeBuilder<Coupon> builder)
		{
		}
	}
}
