using System.Runtime.CompilerServices;
namespace dotnet03_web_blazor.Model.ViewModel;

using System.ComponentModel.DataAnnotations;
public class UserRegister
{
    [Required(ErrorMessage = "UserName cannot be blank!")]
    public string Username { get; set; }
    [Required(ErrorMessage = "Password cannot be blank!")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{6,32}$",
            ErrorMessage = "Password must be 6-32 characters, include at least one uppercase letter, one number, and one special character.")]
    public string Password { get; set; }


    [Required(ErrorMessage = "FullName cannot be blank!")]
    public string FullName { get; set; }

    public bool Gender { get; set; } = true;

    [Required(ErrorMessage = "Please select a country!")]
    public string Country { get; set; }
}
