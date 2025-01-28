using System.ComponentModel.DataAnnotations;

namespace CRUD_MVC_users.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Names { get; set; }

    [Required]
    [MaxLength(50)]
    public string Lastname { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime DateBirth { get; set; }

    [Required]
    public string Gender { get; set; } 
}