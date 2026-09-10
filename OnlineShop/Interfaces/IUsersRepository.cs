using OnlineShop.Areas.Admin.Models;
using OnlineShop.Models;

namespace OnlineShop.Repositories
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