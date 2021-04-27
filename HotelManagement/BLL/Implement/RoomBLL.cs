using AutoMapper;
using HotelManagement.BLL.Interface;
using HotelManagement.DAL.Interface;
using HotelManagement.Model;
using HotelManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.BLL.Implement
{
    public class RoomBLL : IRoomBLL
    {
        private IRoomDAL _iRoomDAL;
        private IMapper _iMapper;
        public RoomBLL(IRoomDAL iRoomDAL, IMapper iMapper)
        {
            _iRoomDAL = iRoomDAL;
            _iMapper = iMapper;
        }
        public List<RoomVM> getAll(int pages, int rows, string orderby)
        {
            int start = (pages-1) * rows;
            int length = rows;
            List<Room> listRoom = _iRoomDAL.getall(start, length, orderby);
            List<RoomVM> listRoomVM = new List<RoomVM>();
            foreach (Room room in listRoom)
            {
                RoomVM roomVM = _iMapper.Map<RoomVM>(room);
                int id = room.RoomIdroomtypeNavigation.IdRoomtype;
                string roomname = room.RoomIdroomtypeNavigation.RotyName;
                roomVM.MapRoomtype.Add(id, roomname);
                foreach(StatusTime statusTime in room.StatusTimes)
                {
                    StatusTimeVM statusTimeVM = _iMapper.Map<StatusTimeVM>(statusTime);
                    statusTimeVM.statusVM = _iMapper.Map<StatusVM>(statusTime.StatimIdstatusNavigation);
                    roomVM.ListStatusTime.Add(statusTimeVM);
                }
                listRoomVM.Add(roomVM);
            }
            return listRoomVM;
        }
    }
}
