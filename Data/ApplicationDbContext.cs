using CRUD_MVC_users.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_MVC_users.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    // DbSet para la entidad User
    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property(u => u.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP"); // Valor por defecto en MySQL

        modelBuilder.Entity<User>()
            .Property(u => u.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP"); // Se actualiza en cada UPDATE
        
        // Configuración para mapear el enum Gender a un string en la base de datos
        modelBuilder.Entity<User>()
            .Property(u => u.Gender)
            .HasConversion<string>();
    }
}