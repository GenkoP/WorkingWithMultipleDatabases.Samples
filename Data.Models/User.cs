using System;

namespace Data.Models
{
    public class User : IEntityKey<Guid>
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
