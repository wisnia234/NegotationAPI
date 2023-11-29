using Microsoft.EntityFrameworkCore;
using Negotation.Domain.Entities;
using Negotation.Domain.Repositories;
using Negotation.Domain.ValueObjects;
using Negotation.Infrastructure.DAL;

namespace Negotation.Infrastructure.Repositories;

internal sealed class UserRepository : IUserRepository
{
    private readonly DbSet<User> _users;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _users = dbContext.Users;
    }
    public async Task AddAsync(User product)
    {
        await _users.AddAsync(product);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
         => await _users.ToListAsync();


    public async Task<User> GetByIdAsync(UserId userId)
        => await _users
        .SingleOrDefaultAsync(x => x.Id == userId);

    public async Task<User> GetByNameAsync(UserName productName)
        => await _users
        .SingleOrDefaultAsync(x => x.Name == productName);

    public async Task RemoveByIdAsync(UserId userId)
    {
        User user = await _users
             .SingleOrDefaultAsync(x => x.Id == userId);

        _users.Remove(user);
    }

    public async Task RemoveByNameAsync(UserName userName)
    {
        User user = await _users
            .SingleOrDefaultAsync(x => x.Name == userName);

        _users.Remove(user);
    }
}
