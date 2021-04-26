using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.ViewModel
{
    public class RoomTypeVM
    {
        public RoomTypeVM()
        {
            /*      ListImgURL = new List<string>();*/
            MapImgUrl = new Dictionary<int, string>();
        }
        public int IdRoomtype { get; set; }
        public string RotyName { get; set; }
        public string RotyDescription { get; set; }
        public decimal RotyCurrentprice { get; set; }
        public int RotyCapacity { get; set; }

        public IDictionary<int, string> MapImgUrl { get; set; }
        /*   public List<string>ListImgURL { get; set;}*/
    }
}
