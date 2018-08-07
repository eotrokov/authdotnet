using System;

namespace Model
{
    public class User
    { 
        public string Username { get; set; }
        public string Password { get; set; }
    }
    
    public enum UserRole
    {
        Normal = 0,
        Admin = 1
    }
}