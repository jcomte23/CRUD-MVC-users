using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRUD_MVC_users.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace CRUD_MVC_users.Models;

[Table("users")] 
[Index(nameof(Email), IsUnique = true)] 
public class User(string name, string lastname, string email, DateOnly dateOfBirth, Gender gender)
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public Guid Id { get; init; }

    [Required]
    [StringLength(100)]
    [Column("name")]
    public string Name { get; set; } = name.Trim().ToLower();

    [Required]
    [StringLength(100)]
    [Column("last_name")]
    public string Lastname { get; set; } = lastname.Trim().ToLower();

    [Required]
    [EmailAddress]
    [StringLength(255)]
    [Column("email")]
    public string Email { get; set; } = email.Trim().ToLower();

    [Required]
    [Column("date_birth")]
    [DataType(DataType.Date)]  
    [Display(Name = "Date of Birth")]  
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]  
    public DateOnly DateOfBirth { get; set; } = dateOfBirth;

    [Required]
    [Column("gender")]
    [EnumDataType(typeof(Gender))] 
    public Gender Gender { get; set; } = gender;

    [Column("created_at")]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedAt { get; init; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; init; }
}