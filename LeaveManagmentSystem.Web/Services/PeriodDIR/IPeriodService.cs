namespace LeaveManagmentSystem.Web.Services.PeriodDIR
{
    public interface IPeriodService
    {
        Task<Period> GetCurrentPeriod();
    }
}
