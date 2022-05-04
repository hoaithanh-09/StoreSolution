using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities.Common;
using Store.Data.Enums;

namespace Store.Data.Configurations
{
    public class OrderPaymentConfigurations : IEntityTypeConfiguration<OrderPayment>
    {
        public void Configure(EntityTypeBuilder<OrderPayment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Status).HasDefaultValue(PaymentStatus.UnpaidInvoice);
            builder.HasOne(x => x.Order).WithMany(x => x.OrderPayments).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Payment).WithMany(x => x.OrderPayments).HasForeignKey(x => x.PaymentId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
