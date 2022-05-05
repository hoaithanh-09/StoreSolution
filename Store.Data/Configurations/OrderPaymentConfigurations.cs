using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Enums;
using Store.Data.Entities;

namespace Store.Data.Configurations
{
    public class OrderPaymentConfigurations : BaseConfigurations<OrderPayment>
    {
        protected override void ConfigureMoreProperties(EntityTypeBuilder<OrderPayment> builder)
        {
            builder
                .Property(x => x.Status)
                .HasDefaultValue(PaymentStatus.UnpaidInvoice);

            builder
                .HasOne(x => x.Order)
                .WithMany(x => x.OrderPayments)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.Payment)
                .WithMany(x => x.OrderPayments)
                .HasForeignKey(x => x.PaymentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
