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
    public int Id { get; set; }

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
    [Column("email")]
    public string Email { get; set; }

    [Required]
    [Column("date_birth")]
    [DataType(DataType.Date)]  
    [Display(Name = "Date of Birth")]  
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]  
    public DateTime DateBirth { get; set; }

    [Required]
    [Column("gender")]
    [EnumDataType(typeof(Gender))] 
    public string Gender { get; set; } 
    
    [Column("created_at")]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}