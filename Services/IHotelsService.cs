using System.Collections.Generic;
using HotelsWebApi.Models;

namespace HotelsWebApi.Services
{
    public interface IHotelsService
    {
        IEnumerable<Hotel> GetHotelList();
        void AddHotel(Hotel hotel);
        void DeleteHotel(int id);
        void DeleteHotelWithName(string name);
    }
}