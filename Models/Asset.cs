using System.ComponentModel.DataAnnotations;

public class Asset
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Category { get; set; }

    [Required]
    public string SerialNumber { get; set; }

    public DateTime AssignedDate { get; set; } = DateTime.Today;

    public string AssignedTo { get; set; }
}
