using HotelManagement.DAL.Interface;
using HotelManagement.Extention;
using HotelManagement.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelManagement.DAL.Implement
{
    public class UserDAL : IUserDAL
    {
        private AppDbContext _appDbContext;
        public UserDAL(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public User findbyid(int id_user)
        {
            var user = _appDbContext.Users.Where(x => x.IdUser == id_user).Include(x => x.UserRoles).ThenInclude(y => y.UserolIdroleNavigation).ThenInclude(z => z.Auths).ThenInclude(t => t.AuthIdmenuNavigation).SingleOrDefault();
            if (user != null) _appDbContext.Entry(user).State = EntityState.Detached;
            return user;
        }

        public List<User> findbyproperty(string name, string code)
        {
            // string clause = "x."+property+"==";
            var predicate = PredicateBuilder.True<User>();
            if (!string.IsNullOrEmpty(code)) predicate = predicate.And(x => x.UserCode == code);

            if (!string.IsNullOrEmpty(name)) predicate = predicate.And(x => x.UserName == name);

            List<User> userlist = _appDbContext.Users.Where(predicate)
                                   .Include(x => x.UserRoles)
                                   .ThenInclude(y => y.UserolIdroleNavigation)
                                   .ThenInclude(z => z.Auths)
                                   .ThenInclude(t => t.AuthIdmenuNavigation).ToList();
            return userlist;
        }

        public void addUser(User user)
        {
            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();
        }

        public void editUser(User user)
        {
            _appDbContext.Entry(user).State = EntityState.Modified;
            _appDbContext.Users.Update(user);
            _appDbContext.SaveChanges();
        }

        public void deleteUser(int idUser)
        {
            User user = _appDbContext.Users.Find(idUser);
            _appDbContext.Remove(user);
            _appDbContext.SaveChanges();
        }

        public int getnextid()
        {
            int id;
            using (var command = _appDbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT IDENT_CURRENT('user')+1";
                _appDbContext.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    result.Read();
                    id = Decimal.ToInt32((decimal)result[0]);
                }
            }
            return id;
        }

    }
}
