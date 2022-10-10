using AutoMapper;
using TruckDriverInfo.Models;
using TruckDriverInfo.Repository;

namespace TruckDriverInfo.Services
{
    public class DriversInfoService : IDriversInfoService
    {
        private readonly ITruckDriverRepository _repository;
        private readonly IMapper _mapper;

        public DriversInfoService(ITruckDriverRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
    }
        public List<TruckDriversDTO> GetDriversByLocation(string location)
        {
            var driversByLocation = _repository.GetDriversByLocation(location);

            List<TruckDriversDTO> driversByLocationDTO = _mapper.Map<List<TruckDriversDTO>>(driversByLocation);
            return driversByLocationDTO; 
        }

    }
}
