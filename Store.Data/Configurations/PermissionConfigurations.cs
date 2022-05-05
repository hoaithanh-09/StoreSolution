using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities;

namespace Store.Data.Configurations
{
    public class PermissionConfigurations : BaseConfigurations<Permission>
    {
        protected override void ConfigureMoreProperties(EntityTypeBuilder<Permission> builder)
        {
        }
    }
}


