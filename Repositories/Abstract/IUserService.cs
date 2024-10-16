using LibraryManagementSystem.Models.Domain;

namespace LibraryManagementSystem.Repositories.Abstract
{
    public interface IUserService
    {
        bool Add(User model);
        bool Update(User model);
        bool Delete(string username);
    }
}
