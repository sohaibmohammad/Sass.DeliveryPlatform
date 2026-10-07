using DeliveryPlatform.Domain.src.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeliveryPlatform.Infrastructure.src.Configuration;

public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Quantity)
            .IsRequired();

        builder.Property(x => x.ReservedQuantity)
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .IsRequired();

        builder.HasIndex(x => x.ProductId)
            .IsUnique();

        builder.HasOne(x => x.Product)
            .WithOne(x => x.Inventory)
            .HasForeignKey<Inventory>(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}