using AutoMapper;
using TruckDriverInfo.Models;

namespace TruckDriverInfo
{
    public class TruckDriverProfile :Profile
    {
        public TruckDriverProfile()
        {
            CreateMap<TruckDriversDAO, TruckDriversDTO>();
        }
    }
}
