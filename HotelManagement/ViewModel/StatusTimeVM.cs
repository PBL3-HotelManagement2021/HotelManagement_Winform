using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.ViewModel
{
    public class StatusTimeVM
    {
        public StatusTimeVM()
        {
           
        }
        public int IdStatim { get; set; }
        public DateTime StatimFromdate { get; set; }
        public DateTime StatimTodate { get; set; }
        public StatusVM statusVM { get; set; }
    }
}
