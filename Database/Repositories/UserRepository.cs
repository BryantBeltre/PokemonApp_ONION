using Microsoft.EntityFrameworkCore;
using Pokemons.Infrastructure.Persistence.Contexts;
using System;
using Pokemons.Core.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokemons.Core.Application.Interfaces;
using Pokemons.Core.Domain.Enities;
using Pokemons.Core.Application.Helpers;
using Pokemons.Core.Application.ViewModel.User;

namespace Application.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationContext _dbContext;

        public UserRepository(ApplicationContext dbContext) : base(dbContext)
        {

            _dbContext = dbContext;

        }

        public override async Task AddAsync(User entity)
        {
            entity.Password = PasswordEncryption.ComputeSha256Hash(entity.Password);
            await base.AddAsync(entity);

        }

        public async Task<User> LoginAsync(LoginViewModel loginView)
        {
            string passwordEncrypy = PasswordEncryption.ComputeSha256Hash(loginView.Password);
            User user = await _dbContext.Set<User>()
                .FirstOrDefaultAsync(user => user.Username == loginView.Username && user.Password == passwordEncrypy);
            return user;

        }
    }
}
