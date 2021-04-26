using HotelManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.BLL.Interface
{
    public interface IRoomTypeBLL
    {
         List<RoomTypeVM> getAll();
        void addRoomType(RoomTypeVM roomTypeVM);
        void editRoomType(RoomTypeVM roomTypeVM);
        void deleteRoomType(int idRoomType);
        RoomTypeVM findbyid(int id);
    }
}
