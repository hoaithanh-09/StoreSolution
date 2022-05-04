using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities.Common;
using System;

namespace Store.Data.Configurations
{
    public class DetailConfigurations : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            builder.HasKey(x => x.Id);

        }
    }
}
