using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Designation { get; set; }
    public string ContactNumber { get; set; }
    public string Address { get; set; }
    public string PostalCode { get; set; }
    public string PermanentAddress { get; set; }
}
