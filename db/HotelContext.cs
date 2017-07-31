using Microsoft.EntityFrameworkCore;
using HotelsWebApi.Models;

namespace HotelsWebApi.db
{
    public class HotelContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }

        public HotelContext(DbContextOptions<HotelContext> options) : base(options) { }
    }
}