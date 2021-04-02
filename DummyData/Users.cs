using System.Collections.Generic;
using dotNetServer.Models;

namespace dotNetServer.DummyData
{
    public class Users
    {
        static private List<User> users = new List<User>();
        static public List<User> GetUsers()
        {
            if (users.Count > 0)
            {
                return users;
            }
            for (int i = 0; i < 5; i++)
            {
                var user = new User();
                user.email = $"user{i+1}@test.com";
                user.password = $"password{i+1}";
                user.isAdmin = false;
                users.Add(user);
            }
            return users;
        }

    }
}