using System;
using System.Collections.Generic;
using System.Linq;
using HotelManagement.DAL.Interface;

using HotelManagement.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace HotelManagement.DAL.Impl
{
    public class StatusTimeDAL : IStatusTImeDAL
    {
            private AppDbContext _appDbContext;
            public StatusTimeDAL(AppDbContext appDbContext){
                _appDbContext = appDbContext;
            }

        public void add(List<StatusTime> listadd)
        {
            try{
                _appDbContext.StatusTimes.AddRange(listadd);
                _appDbContext.SaveChanges();
            }catch(Exception e){
                throw ;
            }

        }

        public void delete(List<int> listdel)
        {
            List<StatusTime>list = new List<StatusTime>();
            foreach(int id in listdel){
                StatusTime statusTime = _appDbContext.StatusTimes.Find(id);
                _appDbContext.Entry(statusTime).State = EntityState.Detached;
                if(statusTime !=null) list.Add(statusTime);
            }
            _appDbContext.RemoveRange(list);
            _appDbContext.SaveChanges();
        }

        public void update(List<StatusTime>listedit){
//             foreach (var entityEntry in _appDbContext.ChangeTracker.Entries())
// {
//     Console.WriteLine(entityEntry);
// }
_appDbContext.ChangeTracker.DetectChanges();
Console.WriteLine(_appDbContext.ChangeTracker.DebugView.LongView);
        //   var transaction = _appDbContext.Database.UseTransaction(_appDbContext.transaction.GetDbTransaction());
            try{
                _appDbContext.StatusTimes.UpdateRange(listedit);
                _appDbContext.SaveChanges();
                // _appDbContext.transaction.Commit();
            }catch(Exception e){
                throw ;
                // _appDbContext.transaction.RollbackToSavepoint("Before update StatusTime");
            }
        }
    }
}