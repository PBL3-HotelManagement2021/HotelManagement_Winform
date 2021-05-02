using AutoMapper;
using HotelManagement.BLL.Interface;
using HotelManagement.DAL.Interface;
using HotelManagement.Model;
using HotelManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelManagement.BLL.Implement
{
    public class RoomBLL : IRoomBLL
    {
        private IRoomDAL _iRoomDAL;
        private IMapper _iMapper;

        private IStatusTImeDAL _iStatusTimeDAL;
        public RoomBLL(IRoomDAL iRoomDAL, IMapper iMapper, IStatusTImeDAL iStatusTimeDAL)
        {
            _iRoomDAL = iRoomDAL;
            _iMapper = iMapper;
            _iStatusTimeDAL = iStatusTimeDAL;
        }

        public void editRoom1(RoomVM roomVM, List<int> listdel)
        {
            Room room = new Room();
            _iMapper.Map(roomVM, room);
            room.RoomIdroomtype = roomVM.MapRoomtype.First().Key;
            foreach (StatusTimeVM statusTimeVM in roomVM.ListStatusTime)
            {
                StatusTime statusTime = new StatusTime();
                _iMapper.Map(statusTimeVM, statusTime);
                // Status status = new Status();
                // _iMapper.Map(statusTimeVM.statusVM,status);
                // statusTime.StatimIdstatusNavigation = status;
                statusTime.StatimIdstatus = statusTimeVM.statusVM.IdStatus;
                statusTime.StatimIdroom = room.IdRoom;
                room.StatusTimes.Add(statusTime);
            }
            try
            {
                _iRoomDAL.update(room);
                if (listdel.Count != 0) _iStatusTimeDAL.delete(listdel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public void editRoom(RoomVM roomVM, List<int> listdel)
        {
            Room room = new Room();
            _iMapper.Map(roomVM, room);
            room.RoomIdroomtype = roomVM.MapRoomtype.First().Key;
            List<StatusTime> listedit = new List<StatusTime>();
            List<StatusTime> listadd = new List<StatusTime>();
            foreach (StatusTimeVM statusTimeVM in roomVM.ListStatusTime)
            {
                StatusTime statusTime = new StatusTime();
                _iMapper.Map(statusTimeVM, statusTime);
                // Status status = new Status();
                // _iMapper.Map(statusTimeVM.statusVM,status);
                // statusTime.StatimIdstatusNavigation = status;
                statusTime.StatimIdstatus = statusTimeVM.statusVM.IdStatus;
                statusTime.StatimIdroom = room.IdRoom;
                if (statusTime.IdStatim != 0) listedit.Add(statusTime);
                else listadd.Add(statusTime);
            }
            try
            {
                _iRoomDAL.update(room);
                if (listdel != null) _iStatusTimeDAL.delete(listdel);
                if (listedit.Count != 0) _iStatusTimeDAL.update(listedit);
                if (listadd.Count != 0) _iStatusTimeDAL.add(listadd);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
       

     

        public List<RoomVM> getAll(int pages, int rows, string orderby)
        {
            int start = (pages - 1) * rows;
            int length = rows;
            List<Room> listRoom = _iRoomDAL.getall(start, length, orderby);
            List<RoomVM> listRoomVM = new List<RoomVM>();
            foreach (Room room in listRoom)
            {
                RoomVM roomVM = _iMapper.Map<RoomVM>(room);
                int id = room.RoomIdroomtypeNavigation.IdRoomtype;
                string roomname = room.RoomIdroomtypeNavigation.RotyName;
                roomVM.MapRoomtype.Add(id, roomname);
                foreach (StatusTime statusTime in room.StatusTimes)
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
