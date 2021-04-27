using HotelManagement.DAL.Interface;
using HotelManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelManagement.DAL.Implement
{
    public class StatusDAL : IStatusDAL
    {
        private AppDbContext _appDbContext;
        public StatusDAL(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<Status> getAll()
        {
            var result = _appDbContext.Statuses.ToList();
            return result;
        }
    }
}
