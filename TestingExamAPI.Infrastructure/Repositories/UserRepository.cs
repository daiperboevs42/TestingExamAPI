using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingExamAPI.Core.Entities;
using TestingExamAPI.Core.Interfaces;

namespace TestingExamAPI.Infrastructure.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly TestingExamAPIContext context;
        public UserRepository(TestingExamAPIContext context)
        {
            this.context = context;
        }

        public User Create(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public User Delete(int id)
        {
            var userToDelete = context.Users.FirstOrDefault(x => x.Id == id);
            if (userToDelete == null)
                throw new InvalidDataException("No user found with given id");
            context.Attach(userToDelete).State = EntityState.Deleted;
            context.SaveChanges();
            return userToDelete;
        }

        public User Get(int id)
        {
            var foundUser = context.Users.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if(foundUser == null)
                throw new InvalidDataException("No user found with given id");
            return foundUser;
        }

        public List<User> GetAll()
        {
            return context.Users.ToList();
        }

        public User Update(User user)
        {
            context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();
            return user;
        }
    }
}
