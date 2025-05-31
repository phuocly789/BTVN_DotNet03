using System.ComponentModel.DataAnnotations;

namespace dotnet03_web_blazor.Model.ViewModel
{
    public class Customer
    {
        [Required(ErrorMessage = "FullName cannot be blank!")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email cannot be blank!")]
        [EmailAddress(ErrorMessage = "Invalid Email format!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone cannot be blank!")]
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "Phone must be 10-11 digits.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Address cannot be blank!")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Message cannot be blank!")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Please select a service!")]
        public string Service { get; set; }
        [Range(typeof(bool), "true", "true", ErrorMessage = "You must agree to the terms.")]
        public bool Agree { get; set; }
    }
}
