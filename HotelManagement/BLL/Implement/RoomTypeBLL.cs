using AutoMapper;
using HotelManagement.BLL.Interface;
using HotelManagement.DAL.Interface;
using HotelManagement.Model;
using HotelManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.BBL.Implement
{
    public class RoomTypeBLL : IRoomTypeBLL
    {
        private IRoomtypeDAL _iRoomTypeDAL;
        private IImgStorageDAL _iImgStorageDAL;
        private readonly IMapper _iMapper;
        public RoomTypeBLL(IMapper iMapper, IRoomtypeDAL iRoomTypeDAL, IImgStorageDAL iImgStorageDAL)
        {
            _iRoomTypeDAL = iRoomTypeDAL;
            _iMapper = iMapper;
            _iImgStorageDAL = iImgStorageDAL;
        }

        public List<RoomTypeVM> getAll()
        {
            var result = _iRoomTypeDAL.getAll();
            List<string> imgUrlList = new List<string>();
            List<RoomTypeVM> listVM = new List<RoomTypeVM>();
            foreach (RoomType roomType in _iRoomTypeDAL.getAll())
            {
                RoomTypeVM roomTypeVM = _iMapper.Map<RoomTypeVM>(roomType);
                foreach (ImgStorage imgStorage in roomType.ImgStorages)
                {
                    roomTypeVM.MapImgUrl.Add(imgStorage.IdImgsto, imgStorage.ImgstoUrl);
                }
                listVM.Add(roomTypeVM);
            }
            return listVM;
        }

        public void addRoomType(RoomTypeVM roomTypeVM)
        {
            int idRoomType = _iRoomTypeDAL.getnextid();
            RoomType roomType = new RoomType();
            List<ImgStorage> imgstolist = new List<ImgStorage>();
            _iMapper.Map(roomTypeVM, roomType);
            foreach (KeyValuePair<int, string> kvp in roomTypeVM.MapImgUrl)
            {
                ImgStorage imgStorage = new ImgStorage();
                imgStorage.ImgstoUrl = kvp.Value;
                imgStorage.ImgstoIdrootyp = idRoomType;
                imgstolist.Add(imgStorage);
            }
            roomType.ImgStorages = imgstolist;
            _iRoomTypeDAL.addRoomtype(roomType);
        }

        public void editRoomType(RoomTypeVM roomTypeVM)
        {
            RoomType roomType = new RoomType();
            _iMapper.Map(roomTypeVM, roomType);
            // foreach(string imgurl in roomTypeVM.ListImgURL){
            //     ImgStorage imgStorage = new ImgStorage();
            // }
            List<int> img_del = new List<int>();
            foreach (KeyValuePair<int, string> kvp in roomTypeVM.MapImgUrl)
            {
                if (kvp.Value == "")
                {
                    img_del.Add(kvp.Key);
                }
                else
                {
                    ImgStorage imgStorage = new ImgStorage();
                    if (kvp.Key > 0) imgStorage.IdImgsto = kvp.Key;

                    imgStorage.ImgstoIdrootyp = roomTypeVM.IdRoomtype;
                    imgStorage.ImgstoUrl = kvp.Value;
                    roomType.ImgStorages.Add(imgStorage);
                }

            }
            foreach (int val in img_del)
            {
                _iImgStorageDAL.delete(val);
            }
            _iRoomTypeDAL.updateRoomtype(roomType);
        }

        public void deleteRoomType(int idRoomType)
        {
            throw new System.NotImplementedException();
        }

        public RoomTypeVM findbyid(int id)
        {
            RoomType roomType = _iRoomTypeDAL.findbyid(id);
            RoomTypeVM roomTypeVM = _iMapper.Map<RoomTypeVM>(roomType);
            foreach (ImgStorage img in roomType.ImgStorages)
            {
                // roomTypeVM.ListImgURL.Add(img.ImgstoUrl);
                roomTypeVM.MapImgUrl.Add(img.IdImgsto, img.ImgstoUrl);
            }
            return roomTypeVM;
        }
    }
}


