using HotelManagement.DAL.Interface;
using HotelManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.DAL.Implement
{
    public class ImgStorageDAL : IImgStorageDAL
    {
        private AppDbContext _appDbContext;
        public ImgStorageDAL(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }
        public void delete(int id)
        {
            ImgStorage imgStorage = _appDbContext.ImgStorages.Find(id);
            _appDbContext.ImgStorages.Remove(imgStorage);
            _appDbContext.SaveChanges();
        }
    }
}

