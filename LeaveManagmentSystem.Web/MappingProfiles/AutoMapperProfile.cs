using AutoMapper;
using LeaveManagmentSystem.Web.Data;
using LeaveManagmentSystem.Web.Models.LeaveAllocationsDIR;
using LeaveManagmentSystem.Web.Models.LeaveTypes;
using LeaveManagmentSystem.Web.Models.PeriodsDIR;

namespace LeaveManagmentSystem.Web.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // leave type
            CreateMap<LeaveType, LeaveTypeReadOnlyVM>();

            CreateMap<LeaveTypeCreateVM, LeaveType>();

            CreateMap<LeaveTypeEditVM, LeaveType>().ReverseMap();

            CreateMap<LeaveType, LeaveTypeDeleteVM>();


            // Leave allocation
            CreateMap<LeaveAllocation, LeaveAllocationVM>();

            CreateMap<Period, PeriodVM>();

            CreateMap<AppicationUser, EmployeeListVM>();
        }
    }
}
