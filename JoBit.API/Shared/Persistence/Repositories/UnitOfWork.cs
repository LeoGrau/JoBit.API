using JoBit.API.Shared.Domain.Repositories;
using JoBit.API.Shared.Persistence.Context;

namespace JoBit.API.Shared.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public AppDbContext AppDbContext { get; set; }

    public UnitOfWork(AppDbContext appDbContext)
    {
        AppDbContext = appDbContext;
    }

    public async Task CompleteAsync()
    {
        await AppDbContext.SaveChangesAsync();
    }
}