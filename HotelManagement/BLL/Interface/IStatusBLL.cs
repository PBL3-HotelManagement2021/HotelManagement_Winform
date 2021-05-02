using System.Collections.Generic;
using HotelManagement.ViewModel;

namespace HotelManagement.BBL.Interface
{
    public interface IStatusBLL
    {
         List<StatusVM> getAll();
    }
}