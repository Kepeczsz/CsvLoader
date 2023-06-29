using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.User.Domain;

namespace Data.DataConfiguration;

internal class ClientEntityConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("Id");
        builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(256);
        builder.Property(x => x.Surname).HasColumnName("Surname").HasMaxLength(256);
        builder.Property(x => x.Email).HasColumnName("Email").HasMaxLength(256);
        builder.Property(x => x.PhoneNumber).HasColumnName("PhoneNumber").HasMaxLength(20);
    }
}