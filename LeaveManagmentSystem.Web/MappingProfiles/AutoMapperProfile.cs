using AutoMapper;
using LeaveManagmentSystem.Web.Data;
using LeaveManagmentSystem.Web.Models.LeaveTypes;

namespace LeaveManagmentSystem.Web.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<LeaveType, IndexReadOnlyVM>()
                .ForMember(dest => dest.Days, opt => opt
                .MapFrom(src => src.DefaultDays));

            CreateMap<LeaveTypeCreateVM, LeaveType>();
        }
    }
}
