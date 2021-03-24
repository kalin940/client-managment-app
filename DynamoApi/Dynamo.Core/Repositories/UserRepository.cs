using Dynamo.Core.Db;
using Dynamo.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dynamo.Core.Repositories
{
    public class UserRepository : IUsersRepository
    {
        private readonly IDynamoDbContext _dbContext;
        public UserRepository(IDynamoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public RepositoryResponse Create(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.Context.SaveChanges();
            return new RepositoryResponse() { IsSuccess = true, ErrorMessage = null};
        }

        public RepositoryResponse Delete(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(p => p.ID == id && !p.IsDeleted);
            if (user != null)
            {
                user.IsDeleted = true;
                _dbContext.Context.SaveChanges();
                return new RepositoryResponse() { IsSuccess = true, ErrorMessage = null };
            }
            return new RepositoryResponse() { IsSuccess = false, ErrorMessage = $"There is no user with id:{id}" };
        }

        public RepositoryResponse Edit(User user)
        {
            var dbUser = _dbContext.Users.FirstOrDefault(p => p.ID == user.ID && !p.IsDeleted);
            if (dbUser != null)
            {
                dbUser = user;
                _dbContext.Context.SaveChanges();
                return new RepositoryResponse() { IsSuccess = true, ErrorMessage = null };
            }
            return new RepositoryResponse() { IsSuccess = false, ErrorMessage = $"There is no user with id:{user.ID}" };
        }

        public User GetById(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(p => p.ID == id && !p.IsDeleted);
            return user;
        }

        public ICollection<User> GetAll()
        {
            var users = _dbContext.Users.Where(p => !p.IsDeleted).ToArray();
            return users;
        }

        public User GetByName(string name)
        {
            var user = _dbContext.Users.FirstOrDefault(p => p.Name.Equals(name));
            return user;
        }
    }
}
