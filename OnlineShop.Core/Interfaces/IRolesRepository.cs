using OnlineShop.Core.Models;

namespace OnlineShop.Core.Interfaces
{
    public interface IRolesRepository
    {
        List<Role> GetAll();

        Role? TryGetByName(string roleName);

        Role? TryGetById(Guid roleId);

        void Add(Role role);
        void Delete(Guid roleId);
    }
}
