using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shouts.Domain.Abstract;
using Shouts.Frontend.Infrastructure.Abstract;
using System.Web.Security;


namespace Shouts.Frontend.Infrastructure.Concrete
{
    public class DatabaseAuthorization : IAuthorization
    {
        private IAuthorizationRepository _repository;
        public DatabaseAuthorization(IAuthorizationRepository repository)
        {
            _repository = repository;
        }
        public bool Login(string id, string password)
        {
            if (_repository.CheckLogin(id, password))
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(id, false, 30);
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));                
                HttpContext.Current.Response.Cookies.Add(authCookie);
                return true;
            }
            return false;
        }

        public void Logoff()
        {
            FormsAuthentication.SignOut();
        }
    }
}