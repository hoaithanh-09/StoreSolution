using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities.Common;

namespace Store.Data.Configurations
{
    public abstract class BaseConfigurations<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            ConfigureMoreProperties(builder);
        }

        protected abstract void ConfigureMoreProperties(EntityTypeBuilder<T> builder);
    }
}

