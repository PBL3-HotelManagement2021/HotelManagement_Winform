using HotelManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.BLL.Interface
{
    public interface IRoomBLL
    {
        List<RoomVM> getAll(int pages, int rows, string orderby);
        void editRoom(RoomVM roomVM, List<int> listdel);
    }
}
