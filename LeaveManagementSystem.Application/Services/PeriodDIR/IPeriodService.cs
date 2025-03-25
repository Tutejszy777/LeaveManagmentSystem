namespace LeaveManagementSystem.Application.Services.PeriodDIR
{
    public interface IPeriodService
    {
        Task<Period> GetCurrentPeriod();
    }
}
