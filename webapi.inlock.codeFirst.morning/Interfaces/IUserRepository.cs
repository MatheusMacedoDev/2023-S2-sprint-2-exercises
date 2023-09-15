using webapi.inlock.codeFirst.morning.Domain;

namespace webapi.inlock.codeFirst.morning.Interfaces
{
    public interface IUserRepository
    {
        void Register(User user);
        User FindUser(string email, string password);
    }
}
