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

        public void update(Room room)
        {
            foreach (var entityEntry in _appDbContext.ChangeTracker.Entries())
            {
                Console.WriteLine(entityEntry);
            }
            try
            {
                bool tracking = _appDbContext.ChangeTracker.Entries<Room>().Any(x => x.Entity.IdRoom == room.IdRoom);
                if (tracking) throw new InvalidOperationException("Error while updating room");
                else
                {
                    //    _appDbContext.transaction = (Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerTransaction)_appDbContext.Database.BeginTransaction();
                    //     _appDbContext.transaction.CreateSavepoint("Before update StatusTime");
                    //     _appDbContext.Entry(room.StatusTimes).State = EntityState.Detached;
                    _appDbContext.Rooms.Update(room);
                    _appDbContext.SaveChanges();
                    _appDbContext.Entry(room).State = EntityState.Detached;
                    //    _appDbContext.transaction.Commit();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public void delete(List<int> listdel)
        {
            List<Room> listRoom = new List<Room>();
            foreach (int i in listdel)
            {
                Room room = _appDbContext.Rooms.Find(i);
                if (room != null) listRoom.Add(room);
            }
            try
            {
                _appDbContext.Rooms.RemoveRange(listRoom);
                _appDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public Room findbyid(int id)
        {
            return _appDbContext.Rooms.Find(id);
        }

        public List<Room> getall(int start, int length, string orderby)
        {

            var result = _appDbContext.Rooms.Include(x => x.RoomIdroomtypeNavigation)
                                            .Include(x => x.StatusTimes)
                                            .ThenInclude(y => y.StatimIdstatusNavigation)
                                            .Skip(start).Take(length)
                                            .AsNoTracking()
                                            .ToList();
            return result;
        }

    }
}
