using System.Linq;
using HotelsWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelsWebApi.db
{
    public static class DbInitializer
    {
        public static void Initialize(HotelContext context)
        {
            context.Database.Migrate();

            if (context.Hotels.Any())
            {
                return;
            }

            var hotels = new Hotel[]
            {
                new Hotel { Name = "Nihi Sumba Island", Location = "Indonesia", Stars = 5 },
                new Hotel { Name = "Singita Sabi Sand,", Location = "South Africa", Stars = 4 },                                  
                new Hotel { Name = "Kamalame Cay", Location = "Andros, Bahamas", Stars = 3 },                                  
                new Hotel { Name = "Hacienda AltaGracia, an Auberge Resort", Location = "Costa Rica", Stars = 5 },                                  
                new Hotel { Name = "Manoir Hovey", Location = "North Hatley, Quebec", Stars = 2 }                                                                                    
            };

            foreach (var hotel in hotels)
            {
                context.Hotels.Add(hotel);
            }

            context.SaveChanges();
        }
    }
}