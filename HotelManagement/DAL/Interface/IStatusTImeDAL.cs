using HotelManagement.Model;
using System.Collections.Generic;


namespace HotelManagement.DAL.Interface
{
    public interface IStatusTImeDAL
    {
         void delete(List<int>listdel);
         void add(List<StatusTime>listadd);
          void update (List<StatusTime>listedit);
    }
}