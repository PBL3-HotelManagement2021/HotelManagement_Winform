using HotelManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.DAL.Interface
{
    public interface IRoomDAL
    {
        List<Room> getall(int page, int rows, string orderby);
        Room findbyid();
    }
}
