using HotelManagement.DAL.Interface;
using HotelManagement.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelManagement.DAL.Implement
{
   public class RoomtypeDAL : IRoomtypeDAL
    {
        private AppDbContext _appDbContext;
        public RoomtypeDAL(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Add(RoomType roomType)
        {
            _appDbContext.RoomTypes.Add(roomType);
            _appDbContext.SaveChanges();
        }

        public List<RoomType> getAll()
        {
            var result = _appDbContext.RoomTypes.Include(x => x.ImgStorages).ToList();
            return result;
        }

        public void addRoomtype(RoomType roomType)
        {
            _appDbContext.RoomTypes.Add(roomType);
            _appDbContext.SaveChanges();
        }

        public void deleteRoomtype(int idRoomtype)
        {
            RoomType roomType = _appDbContext.RoomTypes.Find(idRoomtype);
            _appDbContext.Remove(roomType);
            _appDbContext.SaveChanges();
        }

        public void updateRoomtype(RoomType roomType)
        {
            _appDbContext.RoomTypes.Update(roomType);
            _appDbContext.SaveChanges();
        }


        public int getnextid()
        {
            int id;
            using (var command = _appDbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT IDENT_CURRENT('room_type')+1";
                _appDbContext.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    result.Read();
                    id = Decimal.ToInt32((decimal)result[0]);
                }
            }
            return id;
        }

        public RoomType findbyid(int id)
        {
            RoomType roomType = (RoomType)_appDbContext.RoomTypes.Where(x => x.IdRoomtype == id).Include(x => x.ImgStorages).SingleOrDefault();
            if (roomType != null) _appDbContext.Entry(roomType).State = EntityState.Detached;
            return roomType;
        }
    }
}

