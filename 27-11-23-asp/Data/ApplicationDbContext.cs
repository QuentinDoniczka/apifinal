gusing Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using _27_11_23_asp.Model;

namespace _27_11_23_asp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<_27_11_23_asp.Model.Contact> Contact { get; set; }
        public DbSet<_27_11_23_asp.Model.Groupe> Groupe { get; set; }
        public DbSet<ContactGroup> ContactGroup { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ContactGroup>(opt =>
            {
                opt.HasKey(k => new { k.ContactId, k.GroupeId });
            });
        }
    }
}