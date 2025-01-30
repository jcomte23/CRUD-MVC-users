namespace CRUD_MVC_users.DTOs;

public class UserDto
{
    public string name { get; set; }
    public string lastname { get; set; }
    public string email { get; set; }
    public DateOnly dateBirth { get; set; }
    public string gender { get; set; }
}