using Negotation.Domain.Entities;
using Negotation.Domain.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Negotation.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> GetByIdAsync(UserId productId);
    Task<User> GetByNameAsync(UserName productName);
    Task AddAsync(User product);
    Task RemoveByIdAsync(UserId productId);
    Task RemoveByNameAsync(UserName productName);
}
