using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Shouts.Domain;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using Shouts.Storage.Repositories.Concrete;

namespace Shouts.ShoutsCleaner
{
    class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                switch (args[0])
                {
                    case "-deleteShouts":
                        DeleteShouts(args[1]);
                        break;
                    case "-addaccount":
                        Addaccount(args[1], args[2]);
                        break;
                    case "-deleteaccount":
                        Deleteaccount(args[1]);
                        break;
                }
            }
            catch (Exception)
            {
                ErrorMessages();
                return;
            }
        }

        public static void DeleteShouts(string id)
        {
            Console.WriteLine("Deleting all shouts for user " + id + "...");
            ShoutsRepository repository = new ShoutsRepository();
            string returnMessage = repository.RemoveAllShoutsFromUser(id);
            Console.WriteLine(returnMessage);
            Console.WriteLine("Finished");
        }

        public static void Addaccount(string id, string password)
        {
            Console.WriteLine("Adding new account...");
            AuthorizationRepository repository = new AuthorizationRepository();
            string returnMessage = repository.AddAcount(id, password);
            Console.WriteLine(returnMessage);
            Console.WriteLine("Finished");
        }

        public static void Deleteaccount(string id)
        {
            Console.WriteLine("Deleting account...");
            AuthorizationRepository repository = new AuthorizationRepository();
            string returnMessage = repository.DeleteAccount(id);
            Console.WriteLine(returnMessage);
            Console.WriteLine("Finished");
        }


        public static void ErrorMessages()
        {
            Console.WriteLine("Error! Correct syntax:");
            Console.WriteLine("1) Delete all shouts for account: -deleteShouts [email]");
            Console.WriteLine("2) Add a new account: -addaccount [email] [password]");
            Console.WriteLine("3) Remove an account: -deleteaccount [email]");
        }
    }
}
