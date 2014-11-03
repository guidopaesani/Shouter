namespace Shouts.Domain.Abstract
{
    public interface IAuthorizationRepository
    {
        bool CheckLogin(string id, string password);
    }
}
