using F = ETicaretAPI.Domain.Entities;

namespace ETicaretAPI.Application.Repositories
{
    //:: namespace e karşılık gelir. farklı bir kullanım şekli
    public interface IFileWriteRepository : IWriteRepository<F::File>
    {
    }
}
