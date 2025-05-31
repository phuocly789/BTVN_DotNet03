using System.ComponentModel.DataAnnotations;

namespace dotnet03_web_blazor.Model.ViewModel
{
    public class Course
    {
        [Required(ErrorMessage = "Full name is required.")]
        [MinLength(3, ErrorMessage = "Full name must be at least 3 characters long.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\d{10,12}$", ErrorMessage = "Phone number must be 10–12 digits.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please select a course.")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Please select a study mode.")]
        public bool StudyMode { get; set; }

        [Required(ErrorMessage = "Please select a start date.")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; } // nullable to allow [Required] to trigger

        public string Comments { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "You must agree to the terms.")]
        public bool Agree { get; set; }
    }

    public static class CourseService
    {
        public static List<string> lstCourse { get; set; } =
            new List<string>() { "C# Programming", "Web Development", "Data Science" };
    }
}
