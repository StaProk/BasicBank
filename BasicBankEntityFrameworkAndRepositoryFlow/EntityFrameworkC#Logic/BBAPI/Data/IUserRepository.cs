using BBAPI.Models;

namespace BBAPI.Data
{
    public interface IUserRepository
    {
        public bool SaveChanges();
        public void AddEntity<T>(T entityToAdd);
        public void RemoveEntity<T>(T entityToAdd);
        public IEnumerable<User> GetUsers();
        public User GetSingleUser(int userId);
        public Account GetSingleAccount(int userId);
        public Loan GetSingleLoan(int userId);
    }
}