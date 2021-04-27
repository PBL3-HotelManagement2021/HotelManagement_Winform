using AutoMapper;
using HotelManagement.DAL.Interface;
using HotelManagement.Model;
using HotelManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.BLL.Interface
{
    public class UserBLL : IUserBLL
    {
        private readonly IUserDAL _iUserDAL;
        private readonly IMapper _iMapper;
        public UserBLL(IUserDAL iUserDAL, IMapper iMapper)
        {
            _iUserDAL = iUserDAL;
            _iMapper = iMapper;
        }

        public UserVM getUserByID(int id)
        {
            List<RoleVM> roleVMlist = new List<RoleVM>();
            var user = _iUserDAL.findbyid(1);
            UserVM userVM = _iMapper.Map<UserVM>(user);
            foreach (UserRole userRole in user.UserRoles)
            {
                if (userRole.UserolActiveflag == true)
                {
                    Role role = userRole.UserolIdroleNavigation;
                    RoleVM roleVM = _iMapper.Map<RoleVM>(role);
                    roleVM.IdUserRole = userRole.IdUserol;
                    roleVM.UserRoleActiveFlag = (bool)userRole.UserolActiveflag;
                    roleVMlist.Add(roleVM);
                }
            }
            userVM.roleVMlist = roleVMlist;
            return userVM;
        }

        public List<UserVM> searchUser(string name, string code)
        {
            List<RoleVM> roleVMlist;
            List<UserVM> userVMlist = new List<UserVM>();
            List<MenuVM> menuVMlist;
            var userlist = _iUserDAL.findbyproperty(name, code);
            foreach (User user in userlist)
            {
                UserVM userVM = _iMapper.Map<UserVM>(user);
                roleVMlist = new List<RoleVM>();
                foreach (UserRole userRole in user.UserRoles)
                {
                    if (userRole.UserolActiveflag == true)
                    {
                        Role role = userRole.UserolIdroleNavigation;
                        RoleVM roleVM = _iMapper.Map<RoleVM>(role);
                        menuVMlist = new List<MenuVM>();
                        foreach (Auth auth in userRole.UserolIdroleNavigation.Auths)
                        {
                            if (auth.AuthActiveflag == true && auth.AuthPermission == true)
                            {
                                Menu menu = auth.AuthIdmenuNavigation;
                                MenuVM menuVM = _iMapper.Map<MenuVM>(menu);
                                menuVMlist.Add(menuVM);
                            }
                        }
                        roleVM.menuVMlist = menuVMlist;
                        roleVMlist.Add(roleVM);
                    }
                }
                userVM.roleVMlist = roleVMlist;
                userVMlist.Add(userVM);
            }
            return userVMlist;

        }

        public void addUser(UserVM userVM)
        {
            User user = new User();
            int user_id = _iUserDAL.getnextid();
            List<UserRole> userRolelist = new List<UserRole>();
            _iMapper.Map(userVM, user);

            foreach (RoleVM roleVM in userVM.roleVMlist)
            {
                UserRole userRole = new UserRole();
                userRole.UserolIdrole = roleVM.IdRole;
                userRole.UserolIduser = user_id;
                userRole.UserolActiveflag = true;
                userRolelist.Add(userRole);
            }
            user.UserRoles = userRolelist;
            _iUserDAL.addUser(user);
        }

        public void editUser(UserVM userVM)
        {

            User user = new User();
            List<UserRole> userRolelist = new List<UserRole>();
            _iMapper.Map(userVM, user);

            foreach (RoleVM roleVM in userVM.roleVMlist)
            {
                UserRole userRole = new UserRole();
                userRole.IdUserol = roleVM.IdUserRole;
                userRole.UserolIdrole = roleVM.IdRole;
                userRole.UserolIduser = user.IdUser;
                userRole.UserolActiveflag = roleVM.UserRoleActiveFlag;
                userRolelist.Add(userRole);
            }
            user.UserRoles = userRolelist;
            _iUserDAL.editUser(user);
        }

        public void deleteUser(int idUser)
        {
            _iUserDAL.deleteUser(idUser);
        }
    }
}
