using System.ComponentModel.DataAnnotations;

public class RegisterViewModel
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Username { get; set; }
    [Required, EmailAddress]
    public string Email { get; set; }
    [Required, MinLength(6)]
    public string Password { get; set; }
    [Required]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; }

    public string Designation { get; set; }
    public string ContactNumber { get; set; }
    public string Address { get; set; }
    public string PostalCode { get; set; }
    public string PermanentAddress { get; set; }
}
