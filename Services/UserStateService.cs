namespace FFCProject.Services
{
    public class UserStateService
    {
        public string Email { get; private set; }

        public void SetEmail(string email)
        {
            Email = email;
        }

        public void Clear()
        {
            Email = null;
        }
    }
}
