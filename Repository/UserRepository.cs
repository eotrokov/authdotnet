using System;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class UserRepository
    {
        public List<User> TestUsers;

        public UserRepository()
        {
            TestUsers = new List<User>();
            TestUsers.Add(new User() {Username = "Test1", Password = "Pass1"});
            TestUsers.Add(new User() {Username = "Test2", Password = "Pass2"});
        }

        public User GetUser(string username)
        {
            try
            {
                return TestUsers.First(user => user.Username.Equals(username));
            }
            catch
            {
                return null;
            }
        }
    }
}