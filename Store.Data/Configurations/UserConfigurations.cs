using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities;
using Store.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Store.Data.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
        }
    }
}

