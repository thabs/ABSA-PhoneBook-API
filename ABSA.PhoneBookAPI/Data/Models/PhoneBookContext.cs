using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace ABSA.PhoneBookAPI.Data.Models
{
    /// <inheritdoc />
    /// Relational database model registry for the contact context.
    [ExcludeFromCodeCoverage]
    public class PhoneBookContext : DbContext
    {
      /// <summary>
      ///     Gets or sets a <see cref="DbSet{TEntity}"/> representing contacts.
      /// </summary>
      public virtual DbSet<Contact> Contacts { get; set; }
        
      public PhoneBookContext(DbContextOptions<PhoneBookContext> options) : base(options)
      {    
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
        modelBuilder.Entity<Contact>(entity =>
        {
          entity.Property(e => e.Title)
                .HasMaxLength(50);

          entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

          entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

          entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255);

          entity.Property(e => e.MobileNumber)
                .IsRequired()
                .HasMaxLength(50);

          entity.Property(e => e.DateTimeCreated)
                .IsRequired();
          });
        }
    }
}