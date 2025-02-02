using System.ComponentModel.DataAnnotations;
using CRUD_MVC_users.Models.Enums;

namespace CRUD_MVC_users.DTOs;

public class UserDto
{
    [Required(ErrorMessage = "The name is required.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "The name must be between 2 and 50 characters.")]
    public required string Name { get; init; }

    [Required(ErrorMessage = "The last name is required.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "The last name must be between 2 and 50 characters.")]
    public required string Lastname { get; init; }

    [Required(ErrorMessage = "The email is required.")]
    [EmailAddress(ErrorMessage = "The email format is not valid.")]
    public required string Email { get; init; }

    [Required(ErrorMessage = "The date of birth is required.")]
    [DataType(DataType.Date)]
    public DateOnly DateBirth { get; init; }

    [Required(ErrorMessage = "The gender is required.")]
    [EnumDataType(typeof(Gender))] 
    public Gender Gender { get; init; }
}
