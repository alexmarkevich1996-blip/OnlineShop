using OnlineShop.Models;

namespace OnlineShop.Repositories
{
    public class InMemoryUsersRepository : IUsersRepository
    {
        private readonly List<UserAccount> users = new List<UserAccount>();

        public List<UserAccount> GetAll()
        {
            return users;
        }

        public UserAccount? TryGetByLogin(string login)
        {
            return users?.FirstOrDefault(u => u.Login == login);
        }

        public void Add(UserAccount user)
        {
            user.Id = Guid.NewGuid();
            user.CreationDateTime = DateTime.Now;
            users.Add(user);
        }

        public void Edit(UserAccount user)
        {
            var existingUser = TryGetByLogin(user.Login);

            if(existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Surname = user.Surname;
                existingUser.Age = user.Age;
                existingUser.Phone = user.Phone;
            }
        }

        public void ChangePassword(ChangedPassword password)
        {
            var existingUser = TryGetByLogin(password.Login);

            if(existingUser != null)
            {
                existingUser.Password = password.Password;
            }
        }

        public void Delete(string login)
        {
            var existingUser = TryGetByLogin(login);

            if(existingUser != null)
            {
                users.Remove(existingUser);
            }
        }
    }
}
