using BBAPI.Models;

namespace BBAPI.Data
{
    public class UserRepository : IUserRepository
    {
        DataContextEF _entityFramework;    

        public UserRepository(IConfiguration config)
        {
            _entityFramework = new DataContextEF(config);
        }

        public bool SaveChanges()
        {
            return _entityFramework.SaveChanges() > 0;
        }

        public void AddEntity<T>(T entityToAdd)
        {
            if (entityToAdd != null)
            {
                _entityFramework.Add(entityToAdd);
            }
        }

        public void RemoveEntity<T>(T entityToAdd)
        {
            if (entityToAdd != null)
            {
                _entityFramework.Remove(entityToAdd);
            }
        }

        public IEnumerable<User> GetUsers()
        {
            IEnumerable<User> users = _entityFramework.Users.ToList<User>();
            return users;
        }

        public User GetSingleUser(int userId)
        {
            User? user = _entityFramework.Users
                .Where(u => u.UserId == userId)
                .FirstOrDefault<User>();

            if (user != null)
            {
                return user;
            }
            
            throw new Exception("Failed to Get User");
        }

        public Account GetSingleAccount(int userId)
        {
            Account? account = _entityFramework.Account
                .Where(u => u.UserId == userId)
                .FirstOrDefault<Account>();

            if (account != null)
            {
                return account;
            }
            
            throw new Exception("Failed to Get Account");
        }

        public Loan GetSingleLoan(int userId)
        {
            Loan? loan = _entityFramework.Loan
                .Where(u => u.UserId == userId)
                .FirstOrDefault<Loan>();

            if (loan != null)
            {
                return loan;
            }
            
            throw new Exception("Failed to Get Loan");
        }
    }
}