using webapi.inlock.codeFirst.morning.Contexts;
using webapi.inlock.codeFirst.morning.Domain;
using webapi.inlock.codeFirst.morning.Interfaces;
using webapi.inlock.codeFirst.morning.Utils;

namespace webapi.inlock.codeFirst.morning.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly InlockContext _context;

        public UserRepository()
        {
            _context= new InlockContext();
        }

        public User FindUser(string email, string password)
        {
            User findedUser = _context.Users.FirstOrDefault(user => user.Email == email)!;

            if (findedUser != null)
            {
                if (Cryptography.IsEqualHashes(password, findedUser.Password!))
                {
                    return findedUser;
                }
            }

            return null!;
        }

        public void Register(User user)
        {
            user.Password = Cryptography.GetHashByPassword(user.Password!);

            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
