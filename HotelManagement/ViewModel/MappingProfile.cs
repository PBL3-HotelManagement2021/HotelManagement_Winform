using AutoMapper;
using HotelManagement.Model;


namespace HotelManagement.ViewModel
{
   public  class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<User, UserVM>().ReverseMap();
            CreateMap<Role, RoleVM>().ReverseMap();
            CreateMap<Menu, MenuVM>().ReverseMap();
            CreateMap<RoomType, RoomTypeVM>().ReverseMap();
            CreateMap<RoomVM, Room>().ReverseMap();
            CreateMap<StatusTimeVM, StatusTime>().ReverseMap();
            CreateMap<StatusVM, Status>().ReverseMap();
            // .ForMember(dest =>dest.IdRoomtype ,opt =>opt.MapFrom(src => src.ImgroomImgstoNavigation.ImgroomImgstoNavigation.IdRoomtype) ) 

        }

    }
}
