using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Shouts.Domain;
using Shouts.Domain.Abstract;
using Shouts.Storage.Repositories.Abstract;

namespace Shouts.Storage.Repositories.Concrete
{
    public class ShoutsRepository : MongoRepository, IShoutsRepository
    {
        private MongoCollection<User> Users;

        public ShoutsRepository()
        {
            Users = database.GetCollection<User>("users");
        }

        public List<Shout> GetShoutsByUser(string id)
        {
            var query = Query<User>.Where(User => User.Email == id);
            User user = Users.FindOne(query);
            List<Shout> shoutsList = new List<Shout>();
            shoutsList = user.Shouts;
            return shoutsList ?? new List<Shout>();
        }

        public void AddShout(Domain.Shout newShout)
        {
            var query = Query<User>.Where(User => User.Email == newShout.Id);
            User user = new User();
            user = Users.FindOne(query);
            user.Shouts.Add(newShout);
            Users.Save(user);
        }

        public string RemoveAllShoutsFromUser(string id)
        {
            var query = Query<User>.Where(x => x.Email == id);
            User user = Users.FindOne(query);
            user.Shouts.Clear();
            WriteConcernResult returncode = Users.Save(user);
            return returncode.Response.ToString();
        }
    }
}