using System;
using System.Collections.Generic;
using System.Linq;
using HotelsWebApi.Models;
using HotelsWebApi.DAL;

namespace HotelsWebApi.Services
{
    public class HotelsInfoService 
    {
        private IUnitOfWorkFactory _unitOfWorkFactory;

        public HotelsInfoService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public IEnumerable<string> GetHotelNameList()
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                return unitOfWork.Repository<Hotel>().All().Select(h => h.Name);                
            }
        } 
    }
}