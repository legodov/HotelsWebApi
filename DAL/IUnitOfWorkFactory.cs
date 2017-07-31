using Microsoft.EntityFrameworkCore;

namespace HotelsWebApi.DAL
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
