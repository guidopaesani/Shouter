using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;


namespace Shouts.Domain
{
    public class User
    {
        // private string _email;
        public ObjectId Id { get; set; }

        public User()
        {
            Shouts = new List<Shout>();
        }
        public User(string email, string password)
        {
            Email = email;
            Password = password;
            Shouts = new List<Shout>();
        }
        
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Shout> Shouts { get; set; }


    }
}