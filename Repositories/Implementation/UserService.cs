using LibraryManagementSystem.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibraryManagementSystem.Repositories.Implementation
{
    public class UserService
    {
        private readonly ApplicationDbContext context;
        public UserService(ApplicationDbContext context) { 
            this.context = context;
        }
        public bool Add(User user)
        {
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
                return true;
            }
            catch(Exception ex) {
                return false;
            }
        }
        public bool Delete(string username)
        {
            try
            {
                var user = context.Users.SingleOrDefault(x => x.Username == username);
                context.Users.Remove(user);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
