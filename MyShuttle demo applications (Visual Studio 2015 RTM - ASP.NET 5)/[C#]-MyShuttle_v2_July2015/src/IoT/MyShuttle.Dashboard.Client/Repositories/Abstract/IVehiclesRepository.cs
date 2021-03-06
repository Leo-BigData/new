namespace MyShuttle.Dashboard.Client.Repositories.Abstract
{
    using System.Threading.Tasks;
    using Models;
    using System.Collections.Generic;

    public interface IVehiclesRepository
    {
        Task<VehicleSummaryResult> GetVehiclesDataAsync();
        Task<VehicleDetailResult> GetVehicleDetailAsync(string deviceId);
        Task<IEnumerable<VehicleAlarmResult>> GetVehicleAlarmsAsync(string deviceId);
        Task<IEnumerable<VehicleMilesYearResult>> GetMilesPerYear(string deviceId, int year);
        Task<IEnumerable<VehicleMilesMonthResult>> GetMilesPerMonth(string deviceId, int year, int month);
    }
}