using System.ComponentModel.DataAnnotations;

namespace CRUD_MVC_users.DTOs;

public class UserDto
{
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "El apellido es obligatorio.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "El apellido debe tener entre 2 y 50 caracteres.")]
    public string Lastname { get; set; }

    [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
    [EmailAddress(ErrorMessage = "El formato del correo no es válido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
    [DataType(DataType.Date)]
    [Range(typeof(DateOnly), "1900-01-01", "2024-12-31", ErrorMessage = "La fecha de nacimiento debe estar entre 1900 y 2024.")]
    public DateOnly DateBirth { get; set; }

    [Required(ErrorMessage = "El género es obligatorio.")]
    [RegularExpression("^(M|F)$", ErrorMessage = "El género debe ser 'M' (Masculino) o 'F' (Femenino).")]
    public string Gender { get; set; }
}