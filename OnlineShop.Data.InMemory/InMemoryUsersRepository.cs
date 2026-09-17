using OnlineShop.Core.DTO;
using OnlineShop.Core.Interfaces;
using OnlineShop.Core.Models;

namespace OnlineShop.Data.InMemory
{
    public class InMemoryUsersRepository(IRolesRepository rolesRepository) : IUsersRepository
    {
        private readonly List<User> users = new List<User>();

        public List<User> GetAll()
        {
            return users;
        }

        public User? TryGetByLogin(string login)
        {
            return users?.FirstOrDefault(u => u.Login == login);
        }

        public void Add(User user)
        {
            user.Id = Guid.NewGuid().ToString();
            user.Role = rolesRepository.TryGetByName("User");
            user.CreationDateTime = DateTime.Now;
            users.Add(user);
        }

        public void Edit(User user)
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
        }

        public void Delete(string login)
        {
            var existingUser = TryGetByLogin(login);

            if(existingUser != null)
            {
                users.Remove(existingUser);
            }
        }

        public void ChangeRole(string login, Role? newRole)
        {
            var existingUser = TryGetByLogin(login);

            if(existingUser != null)
            {
                existingUser.Role = newRole;
            }
        }
    }
}
