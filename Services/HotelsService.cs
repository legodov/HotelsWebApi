using System;
using System.Collections.Generic;
using System.Linq;
using HotelsWebApi.Models;
using HotelsWebApi.DAL;

namespace HotelsWebApi.Services
{
    public class HotelsService : IHotelsService
    {
        private IUnitOfWorkFactory _unitOfWorkFactory;

        public HotelsService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public IEnumerable<Hotel> GetHotelList()
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                return unitOfWork.Repository<Hotel>().All();                
            }
        }
        public void AddHotel(Hotel hotel)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                unitOfWork.Repository<Hotel>().Add(hotel);
                unitOfWork.SaveChanges();
            }
        }
        public void DeleteHotel(int id)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var hotelRepository = unitOfWork.Repository<Hotel>();
                var hotels = hotelRepository.Query().Where(h => h.Id == id).ToList();
                foreach (var hotel in hotels)
                    hotelRepository.Delete(hotel);
                unitOfWork.SaveChanges();
            }
        }
        public void DeleteHotelWithName(string name)
        {
            if (name == null) throw new ArgumentNullException();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var hotelRepository = unitOfWork.Repository<Hotel>();
                var hotels = hotelRepository.Query().Where(h => h.Name == name).ToList();
                foreach (var hotel in hotels)
                    hotelRepository.Delete(hotel);
                unitOfWork.SaveChanges();
            }
        }   
    }
}