using AutoMapper;
using LeaveManagmentSystem.Web.Models.LeaveAllocationsDIR;
using LeaveManagmentSystem.Web.Models.LeaveRequestDIR;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagmentSystem.Web.Services.LeaveRequestDIR;

public class LeaveRequestService(IMapper _mapper, UserManager<AppicationUser> _userManager, IHttpContextAccessor _httpContextAccessor, ApplicationDbContext _context) : ILeaveRequestService
{
    public async Task CanceLeaveRequest(int leaveRequestId)
    {
        var leaveRequest = await _context.LeaveRequests.FindAsync(leaveRequestId);
        leaveRequest.LeaveStatusId = (int)LeaveRequestStatusEnum.Canceled;


        var currentDate = DateTime.Now;
        var period = await _context.Periods.SingleAsync(q => q.EndDate.Year == currentDate.Year);

        var numberOfDays = leaveRequest.DateEnd.DayNumber - leaveRequest.DateOnly.DayNumber;
        var allocation = await _context.LeaveAllocations
            .FirstAsync(q => q.LeaveTypeId == leaveRequest.LeaveTypeId 
            && q.EmployeeId == leaveRequest.EmployeeId
            && q.PeriodId == period.Id);

        allocation.Days += numberOfDays;

        await _context.SaveChangesAsync();
    }

    public async Task CreateLeaveRequest(LeaveRequestCreateVM model)
    {
        var leaveRequest = _mapper.Map<LeaveRequest>(model);

        var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        leaveRequest.EmployeeId = user.Id;

        leaveRequest.LeaveStatusId = (int)LeaveRequestStatusEnum.Pending;

        _context.Add(leaveRequest);

        //deduct allocations
        var currentDate = DateTime.Now;
        var period = await _context.Periods.SingleAsync(q => q.EndDate.Year == currentDate.Year);

        var numberOfDays = model.DateEnd.DayNumber - model.DateOnly.DayNumber;
        var allocationToDeduct = await _context.LeaveAllocations
            .FirstAsync(q => q.LeaveTypeId == model.LeaveTypeId 
            && q.EmployeeId == user.Id
            && q.PeriodId == period.Id
            );

        allocationToDeduct.Days -= numberOfDays;

        await _context.SaveChangesAsync();

    }

    public async Task<EmployeeLeaveRequestListVM> GetAllLeaveRequests()
    {
        var leaveRequest = await _context.LeaveRequests
            .Include(q => q.LeaveType) // join the leavetype
            .ToListAsync();

        var leaveRequestModel =  leaveRequest.Select(q => new LeaveRequestReadOnlyVM
        {
            DateOnly = q.DateOnly,
            DateEnd = q.DateEnd,
            Days = q.DateEnd.DayNumber - q.DateOnly.DayNumber,
            LeaveType = q.LeaveType.Name,
            LeaveRequestsStatus = (LeaveRequestStatusEnum)q.LeaveStatusId,
            Id = q.Id
        }).ToList();

        var model = new EmployeeLeaveRequestListVM
        {
            ApprovedRequests = leaveRequest.Count(q => q.LeaveStatusId == (int)LeaveRequestStatusEnum.Approved),
            PendingRequests = leaveRequest.Count(q => q.LeaveStatusId == (int)LeaveRequestStatusEnum.Pending),
            DeclinedRequests = leaveRequest.Count(q => q.LeaveStatusId == (int)LeaveRequestStatusEnum.Declined),
            TotalRequests = leaveRequest.Count,
            LeaveRequests = leaveRequestModel
        };

        return model;
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


    public async Task ReviewLeaveRequest(int id, bool approved)
    {
        var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        var leaveRequest = await _context.LeaveRequests.FindAsync(id);
        leaveRequest.LeaveStatusId = approved ? (int)LeaveRequestStatusEnum.Approved : (int)LeaveRequestStatusEnum.Declined;

        leaveRequest.ReviewerId = user.Id;

        if(!approved)
        {
            var currentDate = DateTime.Now;
            var period = await _context.Periods.SingleAsync(q => q.EndDate.Year == currentDate.Year);

            var numberOfDays = leaveRequest.DateEnd.DayNumber - leaveRequest.DateOnly.DayNumber;
            var allocation = await _context.LeaveAllocations
                .FirstAsync(q => q.LeaveTypeId == leaveRequest.LeaveTypeId 
                && q.EmployeeId == leaveRequest.EmployeeId
                && q.PeriodId == period.Id);

            allocation.Days += numberOfDays;
        }
        await _context.SaveChangesAsync();
    }

    public async Task<ReviewLeaveRequestVM> GetLeaveRequestForReview(int id)
    {
        var leaveRequest = await _context.LeaveRequests
            .Include(q => q.LeaveType)
            .FirstAsync(q => q.Id == id);

        var user = await _userManager.FindByIdAsync(leaveRequest.EmployeeId);

        var model = new ReviewLeaveRequestVM
        {
            DateOnly = leaveRequest.DateOnly,
            DateEnd = leaveRequest.DateEnd,
            Days = leaveRequest.DateEnd.DayNumber - leaveRequest.DateOnly.DayNumber,
            LeaveRequestsStatus = (LeaveRequestStatusEnum)leaveRequest.LeaveStatusId,
            Id = leaveRequest.Id,
            LeaveType = leaveRequest.LeaveType.Name,
            RequestComments = leaveRequest.RequestComments,
            Employee = new EmployeeListVM
            {
                Id = leaveRequest.EmployeeId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            }
        };

        return model;
    }


    public async Task<bool> RequestDatesExceedAllocation(LeaveRequestCreateVM model)
    {
        var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        var numberOfDays = model.DateEnd.DayNumber - model.DateOnly.DayNumber;

        var currentDate = DateTime.Now;
        var period = await _context.Periods.SingleAsync(q => q.EndDate.Year == currentDate.Year);
        var allocation = await _context.LeaveAllocations
            .FirstAsync(q => q.LeaveTypeId == model.LeaveTypeId 
            && q.EmployeeId == user.Id
            && q.PeriodId == period.Id);

        return allocation.Days < numberOfDays;
    }

}
