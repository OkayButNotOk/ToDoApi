using Microsoft.EntityFrameworkCore;
using ToDoApi.Models;

namespace ToDoApi
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options) { }

        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User entity konfigürasyonu
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id); // Primary key tanımı
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50); // Username zorunlu ve max 50 karakter
                entity.Property(e => e.PasswordHash).IsRequired(); // PasswordHash zorunlu
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100); // Email zorunlu ve max 100 karakter
                entity.Property(e => e.CreatedAt).IsRequired(); // CreatedAt zorunlu
                entity.Property(e => e.UpdatedAt).IsRequired(false); // UpdatedAt opsiyonel
            });

            // Task entity konfigürasyonu
            modelBuilder.Entity<Models.Task>(entity =>
            {
                entity.HasKey(e => e.Id); // Primary key tanımı
                entity.Property(e => e.Title).IsRequired().HasMaxLength(100); // Title zorunlu ve max 100 karakter
                entity.Property(e => e.Description).IsRequired().HasMaxLength(500); // Description zorunlu ve max 500 karakter
                entity.Property(e => e.Status).IsRequired().HasMaxLength(20); // Status zorunlu ve max 20 karakter
                entity.Property(e => e.CreatedAt).IsRequired(); // CreatedAt zorunlu
                entity.Property(e => e.UpdatedAt).IsRequired(false); // UpdatedAt opsiyonel

            });
        }
    }
    
    
    
}
