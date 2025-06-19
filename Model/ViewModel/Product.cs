using System.ComponentModel.DataAnnotations;

public class Product
{
    [Required(ErrorMessage = "Id is required")]
    public string id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string name { get; set; }

    [Required(ErrorMessage = "Price is required")]
    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Price must be a valid number")]
    public string price { get; set; }

    [Required(ErrorMessage = "Image is required")]
    public string img { get; set; }

    [Required(ErrorMessage = "Description is required")]
    public string description { get; set; }

    [Required(ErrorMessage = "Type is required")]
    public string type { get; set; }

    public bool deleted { get; set; } = false;
}
