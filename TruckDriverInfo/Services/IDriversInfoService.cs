using TruckDriverInfo.Models;

namespace TruckDriverInfo.Services
{
    public interface IDriversInfoService
    {
        List<TruckDriversDTO> GetDriversByLocation(string location) ;
    }
}
