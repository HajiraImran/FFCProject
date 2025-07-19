using System;

namespace FFCProject.Services
{
    public class UserStateService
    {
        public string Email { get; set; }

        public void Clear()
        {
            Email = null;
        }
    }
}
