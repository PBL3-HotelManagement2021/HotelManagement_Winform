using System.Collections.Generic;
using AutoMapper;
using HotelManagement.BBL.Interface;
using HotelManagement.DAL.Interface;
using HotelManagement.Model;
using HotelManagement.ViewModel;

namespace HotelManagement.BBL.Implement
{
    public class StatusBLL : IStatusBLL
    {
        private IStatusDAL _iStatusDAL;
        private IMapper _iMapper;
        public StatusBLL(IStatusDAL iStatusDAL, IMapper iMapper){
            _iStatusDAL = iStatusDAL;
            _iMapper = iMapper;
        }
        public List<StatusVM> getAll()
        {
            List<Status> list = _iStatusDAL.getAll();
            List<StatusVM> listVm = new List<StatusVM>();
            foreach(Status status in list){
                StatusVM statusVM = _iMapper.Map<StatusVM>(status);
                listVm.Add(statusVM);
            }
            return listVm;
        }
    }
}