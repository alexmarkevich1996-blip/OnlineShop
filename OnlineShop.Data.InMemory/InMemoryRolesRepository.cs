using OnlineShop.Core.Interfaces;
using OnlineShop.Core.Models;

namespace OnlineShop.Data.InMemory
{
    public class InMemoryRolesRepository : IRolesRepository
    {
        private readonly List<Role> _roles = 
            [
                new Role(){Id = Guid.NewGuid(), Name = "Admin"},
                new Role(){Id = Guid.NewGuid(), Name = "Moderator"},
                new Role(){Id = Guid.NewGuid(), Name = "User"},
                new Role(){Id = Guid.NewGuid(), Name = "Developer"},
                new Role(){Id = Guid.NewGuid(), Name = "Guest"},
            ];
        
        public void Add(Role role)
        {
            role.Id = Guid.NewGuid();
            _roles.Add(role);
        }

        public void Delete(Guid roleId)
        {
            var existingRole = TryGetById(roleId);

            if(existingRole != null)
            {
                _roles.Remove(existingRole);
            }

        }

        public List<Role> GetAll() => _roles;

        public Role? TryGetById(Guid roleId) =>
            _roles.FirstOrDefault(role => role.Id == roleId);

        public Role? TryGetByName(string roleName)
        {
            return _roles.FirstOrDefault(role => role.Name == roleName);
        }
    }
}
