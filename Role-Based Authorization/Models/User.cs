﻿namespace Role_Based_Authorization.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // "Admin", "User", etc.
    }
}
