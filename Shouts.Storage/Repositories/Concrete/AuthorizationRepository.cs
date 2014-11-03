using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Shouts.Domain;
using Shouts.Domain.Abstract;
using Shouts.Storage.Repositories.Abstract;

namespace Shouts.Storage.Repositories.Concrete
{
    public class AuthorizationRepository :  MongoRepository, IAuthorizationRepository
    {
        private MongoCollection<User> users;       
        
        public AuthorizationRepository() : base()
        {
            users = database.GetCollection<User>("users");
        }

        public bool CheckLogin(string id, string password)
        {
            var query = Query<User>.Where(user => user.Email == id && user.Password == password);
            var match = users.FindOne(query);
            return (match != null);
        }

        public string AddAcount(string email, string password)
        {
            if (email == null || password == null) return "ERROR! wrong params";
            User newUser = new User(email, password);
            WriteConcernResult result = users.Save(newUser);
            return result.Response.ToString();
        }

        public string DeleteAccount(string email)
        {
            if (email == null) return "ERROR! wrong params";
            
            var query = Query<User>.Where(user => user.Email == email);
            WriteConcernResult result = users.Remove(query);
            return result.Response.ToString();
        }
    }
}