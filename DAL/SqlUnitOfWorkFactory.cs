using HotelsWebApi.db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HotelsWebApi.DAL
{
    public class SqlUnitOfWorkFactory : IUnitOfWorkFactory
    {   
        public IUnitOfWork Create()
        {     
            var optionsBuilder = new DbContextOptionsBuilder<HotelContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-0NACH57;Database=HotelDb;Trusted_Connection=true");
            return new UnitOfWork(new HotelContext(optionsBuilder.Options));
        }
    }
}