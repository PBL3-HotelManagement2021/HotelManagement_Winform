using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.ViewModel
{
    public class MenuVM
    {
        public int IdMenu { get; set; }
        public int MenuParentid { get; set; }
        public string MenuUrl { get; set; }
        public string MenuName { get; set; }
        public int MenuOrderindex { get; set; }
        public bool MenuActiveflag { get; set; }
    }
}
