using AutoMapper;

namespace LeaveManagementSystem.Application.MappingProfiles
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

            CreateMap<LeaveAllocation, LeaveAllocationEditVM>();

            //Leave Request
            CreateMap<LeaveRequestCreateVM, LeaveRequest>();

        }
    }
}
