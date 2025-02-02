using System.ComponentModel.DataAnnotations;
using CRUD_MVC_users.Models.Enums;

namespace CRUD_MVC_users.DTOs;

public class UserDto
{
    [Required(ErrorMessage = "The name is required.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "The name must be between 2 and 50 characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "The last name is required.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "The last name must be between 2 and 50 characters.")]
    public string Lastname { get; set; }

    [Required(ErrorMessage = "The email is required.")]
    [EmailAddress(ErrorMessage = "The email format is not valid.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "The date of birth is required.")]
    [DataType(DataType.Date)]
    public DateOnly DateBirth { get; set; }

    [Required(ErrorMessage = "The gender is required.")]
    public Gender Gender { get; set; }
}
