using HotelManagement.DAL.Interface;
using HotelManagement.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelManagement.DAL.Implement
{
    public class RoomDAL : IRoomDAL
    {
        private AppDbContext _appDbContext;
        public RoomDAL(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Room findbyid()
        {
            throw new System.NotImplementedException();
        }

        public List<Room> getall(int start, int length, string orderby)
        {

            var result = _appDbContext.Rooms.Include(x => x.RoomIdroomtypeNavigation).Include(x =>x.StatusTimes).ThenInclude(y =>y.StatimIdstatusNavigation).Skip(start).Take(length).ToList();
            return result;
        }
    }
}
