using HotelManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.DAL.Interface
{
    public interface IUserDAL
    {
        User findbyid(int id_user);
        List<User> findbyproperty(string name, string code);
        void addUser(User user);
        void editUser(User user);
        void deleteUser(int idUser);
        int getnextid();
    }
}
