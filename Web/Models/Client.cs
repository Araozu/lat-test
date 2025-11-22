using System.ComponentModel.DataAnnotations;

namespace Acide.Latesa.Web.Models;

public class Client
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = string.Empty;
    
    [Phone(ErrorMessage = "Invalid phone number")]
    [StringLength(20, ErrorMessage = "Phone cannot exceed 20 characters")]
    public string Phone { get; set; } = string.Empty;
    
    [StringLength(100, ErrorMessage = "Company name cannot exceed 100 characters")]
    public string Company { get; set; } = string.Empty;
    
    public DateTime CreatedDate { get; set; }
}
