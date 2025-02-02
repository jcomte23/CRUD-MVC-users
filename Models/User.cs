using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRUD_MVC_users.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace CRUD_MVC_users.Models;

[Table("users")] 
[Index(nameof(Email), IsUnique = true)] 
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    [Column("name")]
    public string Name { get; set; }

    [Required]
    [StringLength(100)]
    [Column("last_name")]
    public string Lastname { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(255)]
    [Column("email")]
    public string Email { get; set; }

    [Required]
    [Column("date_birth")]
    [DataType(DataType.Date)]  
    [Display(Name = "Date of Birth")]  
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]  
    public DateOnly DateBirth { get; set; }
    
    [Required]
    [Column("gender")]
    [EnumDataType(typeof(Gender))] 
    public Gender Gender { get; set; } 
    
    [Column("created_at")]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    public User(string name, string lastname, string email, DateOnly dateBirth , Gender gender )
    {
        Name = name.Trim().ToLower();
        Lastname = lastname.Trim().ToLower();
        Email = email.Trim().ToLower();
        DateBirth = dateBirth;
        Gender = gender;
    }
}