using OnlineShop.Core.DTO;
using OnlineShop.Core.Models;

namespace OnlineShop.Core.Interfaces
{
    public interface IUsersRepository
    {
        void Add(User user);
        void Edit(User user);
        void ChangePassword(ChangedPassword password);
        void ChangeRole(string login, Role? newRole);
        void Delete(string login);
        List<User> GetAll();
        User? TryGetByLogin(string name);


    }
}