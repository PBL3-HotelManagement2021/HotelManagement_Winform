using HotelManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.BLL.Interface
{
    public interface IUserBLL
    {
        UserVM getUserByID(int id);
        List<UserVM> searchUser(string name, string code);
        void addUser(UserVM userVM);
        void editUser(UserVM userVM);
        void deleteUser(int idUser);
    }
}
