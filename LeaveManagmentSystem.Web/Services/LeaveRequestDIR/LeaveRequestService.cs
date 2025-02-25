using AutoMapper;
using LeaveManagmentSystem.Web.Models.LeaveRequestDIR;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagmentSystem.Web.Services.LeaveRequestDIR;

public class LeaveRequestService(IMapper _mapper, UserManager<AppicationUser> _userManager, IHttpContextAccessor _httpContextAccessor, ApplicationDbContext _context) : ILeaveRequestService
{
    public Task CanceLeaveRequest(int leaveRequestId)
    {
        throw new NotImplementedException();
    }

    public async Task CreateLeaveRequest(LeaveRequestCreateVM model)
    {
        var leaveRequest = _mapper.Map<LeaveRequest>(model);

        var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        leaveRequest.EmployeeId = user.Id;

        leaveRequest.LeaveStatusId = (int)LeaveRequestStatusEnum.Pending;

        _context.Add(leaveRequest);
        
        //deduct allocations
        var numberOfDays = model.DateEnd.DayNumber - model.DateOnly.DayNumber;
        var allocationToDeduct = await _context.LeaveAllocations
            .FirstAsync(q => q.LeaveTypeId == model.LeaveTypeId && q.EmployeeId == user.Id);

        allocationToDeduct.Days -= numberOfDays;

        await _context.SaveChangesAsync();

    }

    public Task<LeaveRequestReadOnlyVM> GetAllLeaveRequests()
    {
        throw new NotImplementedException();
    }

    public async Task<List<LeaveRequestReadOnlyVM>> GetEmployeeLeaveRequest()
    {
        var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        var leaveRequest = await _context.LeaveRequests
            .Include(q => q.LeaveType) // join the leavetype
            .Where(q => q.EmployeeId == user.Id)
            .ToListAsync();

        var model = leaveRequest.Select(q => new LeaveRequestReadOnlyVM
        {
            DateOnly = q.DateOnly,
            DateEnd = q.DateEnd,
            Days = q.DateEnd.DayNumber - q.DateOnly.DayNumber,
            LeaveType = q.LeaveType.Name,
            LeaveRequestsStatus = (LeaveRequestStatusEnum)q.LeaveStatusId,
            Id = q.Id
        }).ToList();

        return model;
    }

    public async Task<bool> RequestDatesExceedAllocation(LeaveRequestCreateVM model)
    {
        var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        var numberOfDays = model.DateEnd.DayNumber - model.DateOnly.DayNumber;
        var allocation = await _context.LeaveAllocations
            .FirstAsync(q => q.LeaveTypeId == model.LeaveTypeId && q.EmployeeId == user.Id);

        return allocation.Days < numberOfDays;
    }

    public Task ReviewLeaveRequest(ReviewLeaveRequestVM model)
    {
        throw new NotImplementedException();
    }
}
