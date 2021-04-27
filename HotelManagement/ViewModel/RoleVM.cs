using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.ViewModel
{
    public class RoleVM
    {

        public int IdRole { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public List<MenuVM> menuVMlist { get; set; }
        public int IdUserRole { get; set; }
        public bool UserRoleActiveFlag { get; set; }
    }
}
