using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities;

namespace Store.Data.Configurations
{
    public class PaymentConfigurations : BaseConfigurations<Payment>
    {
        protected override void ConfigureMoreProperties(EntityTypeBuilder<Payment> builder)
        {
        }
    }
}
