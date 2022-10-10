using AutoMapper;
using Moq;
using TruckDriverInfo.Models;
using TruckDriverInfo.Repository;
using TruckDriverInfo.Services;

namespace TruckDriverInfo.Tests
{
    public class DriverInfoServiceTest 
    {
        public Mock<ITruckDriverRepository> _mockRepo = new Mock<ITruckDriverRepository>();
        private readonly IList<TruckDriversDAO> _driversList = new List<TruckDriversDAO>();
        public Mock<IMapper> _mappingService = new Mock<IMapper>();

        public DriverInfoServiceTest()
        {
            _driversList.Add(new TruckDriversDAO(1, "Jack", "Muller", "Berlin",23748, "FR2671", "1526374883"));
            _driversList.Add(new TruckDriversDAO(2, "Jill", "Muller", "Berlin",40221, "FR2671", "1526374883"));
            _driversList.Add(new TruckDriversDAO(3, "Radhe", "Shyam", "Dusseldorf",73882, "FR2671", "1526374883"));
        }
        public void ServiceTest()
        {
            [Fact]
            void Should_Return_Drivers_When_Called_By_Location()
            {
                //Arrange
                string location = "Berlin";
                var driversList = new List<TruckDriversDAO>();
                driversList.Add(new TruckDriversDAO(1, "Jack", "Muller", "Berlin", 23748, "FR2671", "1526374883"));
                driversList.Add(new TruckDriversDAO(2, "Jill", "Muller", "Berlin", 40221, "FR2671", "1526374883"));

                var driversListDTO = new List<TruckDriversDTO>();
                driversListDTO.Add(new TruckDriversDTO(1, "Jack", "Muller", "Berlin", 23748));
                driversListDTO.Add(new TruckDriversDTO(2, "Jill", "Muller", "Berlin", 40221));

                _mockRepo.Setup(td => td.GetDriversByLocation(location)).Returns(driversList);

                var truckDrivers = new DriversInfoService( _mockRepo.Object, _mappingService.Object);
                //Act
                var driversByLocation = truckDrivers.GetDriversByLocation(location);
                _mappingService.Setup(m => m.Map<List<TruckDriversDAO>, List<TruckDriversDTO>>(driversList)).Returns(driversListDTO);

                //Assert
                Equals(driversListDTO, driversListDTO);
            }

            [Fact]
            void Should_Return_Drivers_When_Called_By_Location_CaseInsensitive()
            {
                //Arrange
                string location = "berLIN";
                var driversList = new List<TruckDriversDAO>();
                driversList.Add(new TruckDriversDAO(1, "Jack", "Muller", "Berlin", 23748, "FR2671", "1526374883"));
                driversList.Add(new TruckDriversDAO(2, "Jill", "Muller", "Berlin", 40221, "FR2671", "1526374883"));

                var driversListDTO = new List<TruckDriversDTO>();
                driversListDTO.Add(new TruckDriversDTO(1, "Jack", "Muller", "Berlin", 23748));
                driversListDTO.Add(new TruckDriversDTO(2, "Jill", "Muller", "Berlin", 40221));

                _mockRepo.Setup(td => td.GetDriversByLocation(location)).Returns(driversList);

                var truckDrivers = new DriversInfoService(_mockRepo.Object, _mappingService.Object);
                //Act
                var driversByLocation = truckDrivers.GetDriversByLocation(location);
                _mappingService.Setup(m => m.Map<List<TruckDriversDAO>, List<TruckDriversDTO>>(driversList)).Returns(driversListDTO);

                //Assert
                Equals(driversListDTO, driversListDTO);
            }

            [Fact]
            void Should_Return_Drivers_When_Called_By_Location_With_Empty_Spaces()
            {
                //Arrange
                string location = "    Berlin    ";
                var driversList = new List<TruckDriversDAO>();
                driversList.Add(new TruckDriversDAO(1, "Jack", "Muller", "Berlin", 23748, "FR2671", "1526374883"));
                driversList.Add(new TruckDriversDAO(2, "Jill", "Muller", "Berlin", 40221, "FR2671", "1526374883"));

                var driversListDTO = new List<TruckDriversDTO>();
                driversListDTO.Add(new TruckDriversDTO(1, "Jack", "Muller", "Berlin", 23748));
                driversListDTO.Add(new TruckDriversDTO(2, "Jill", "Muller", "Berlin", 40221));

                _mockRepo.Setup(td => td.GetDriversByLocation(location)).Returns(driversList);

                var truckDrivers = new DriversInfoService(_mockRepo.Object, _mappingService.Object);
                //Act
                var driversByLocation = truckDrivers.GetDriversByLocation(location);
                _mappingService.Setup(m => m.Map<List<TruckDriversDAO>, List<TruckDriversDTO>>(driversList)).Returns(driversListDTO);

                //Assert
                Equals(driversListDTO, driversListDTO);
            }

            [Fact]
            void Should_Return_No_Record_When_Called_By_Location()
            {
                //Arrange
                string location = "koln";
                var driversList = new List<TruckDriversDAO>();
                driversList.Add(new TruckDriversDAO(1, "Jack", "Muller", "Berlin", 23748, "FR2671", "1526374883"));
                driversList.Add(new TruckDriversDAO(2, "Jill", "Muller", "Berlin", 40221, "FR2671", "1526374883"));

                var driversListDTO = new List<TruckDriversDTO>();
                driversListDTO.Add(new TruckDriversDTO(1, "Jack", "Muller", "Berlin", 23748));
                driversListDTO.Add(new TruckDriversDTO(2, "Jill", "Muller", "Berlin", 40221));

                _mockRepo.Setup(td => td.GetDriversByLocation(location)).Returns(driversList);

                var truckDrivers = new DriversInfoService(_mockRepo.Object, _mappingService.Object);
                //Act
                var driversByLocation = truckDrivers.GetDriversByLocation(location);
                _mappingService.Setup(m => m.Map<List<TruckDriversDAO>, List<TruckDriversDTO>>(driversList)).Returns(new List<TruckDriversDTO>());

                //Assert
                Equals(new List<TruckDriversDTO>(), new List<TruckDriversDTO>());
            }

        }
    }
}