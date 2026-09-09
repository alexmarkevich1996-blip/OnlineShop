using OnlineShop.Models;

namespace OnlineShop.Repositories
{
    public interface IUsersRepository
    {
        void Add(UserAccount user);
        void Edit(UserAccount user);
        void ChangePassword(ChangedPassword password);
        void Delete(string login);
        List<UserAccount> GetAll();
        UserAccount? TryGetByLogin(string name);


    }
}