namespace FFCProject.Models
{
    public class OtpEntry
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string OTP { get; set; }
        public DateTime Expiry { get; set; }
    }
}
