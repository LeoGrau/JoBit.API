using JoBit.API.Shared.Persistence.Context;

namespace JoBit.API.Shared.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext AppDbContext;

    public BaseRepository(AppDbContext appDbContext)
    {
        AppDbContext = appDbContext;
    }
}