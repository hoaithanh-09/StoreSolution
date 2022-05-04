using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities;

namespace Store.Data.Configurations
{
    public class RolePermissionConfigurations : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}

