using Negotation.Infrastructure.DAL;
using System;
using System.Threading.Tasks;

namespace Negotation.Infrastructure.UnitOfWork;

internal sealed class DbUnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;

    public DbUnitOfWork(ApplicationDbContext dbContext)
        => _dbContext = dbContext;

    public async Task ExecuteAsync(Func<Task> func)
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync();

        try
        {
            await func();
            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}
