using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.ViewModel
{
    class UserVM
    {
        public class UserVM
        {

            public int IdUser { get; set; }
            public string UserName { get; set; }
            public int UserPhoto { get; set; }
            public string UserGmail { get; set; }
            public string UserPhone { get; set; }
            public bool UserGender { get; set; }
            public bool UserActiveflag { get; set; }
            public string UserCode { get; set; }

            public List<RoleVM> roleVMlist { get; set; }
        }
    }
}
