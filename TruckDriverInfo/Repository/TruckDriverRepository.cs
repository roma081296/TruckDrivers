using TruckDriverInfo.Controllers;
using TruckDriverInfo.Models;
namespace TruckDriverInfo.Repository
{
    public class TruckDriverRepository : ITruckDriverRepository
    {
        private readonly IList<TruckDriversDAO> driversList = new List<TruckDriversDAO>();
        private readonly ILogger<TruckController> _logger;
        public TruckDriverRepository(ILogger<TruckController> logger)
        {
            driversList.Add(new TruckDriversDAO(1, "Jack", "Muller", "Berlin",2718, "FR2671", "1526374883"));
            driversList.Add(new TruckDriversDAO(2, "Jill", "Muller", "Berlin", 2526, "FR2671", "1526374883"));
            driversList.Add(new TruckDriversDAO(3, "Radhe", "Shyam", "Dusseldorf", 2387, "FR2671", "1526374883"));
            _logger = logger;

        }

        public IList<TruckDriversDAO> GetAll()
        {
            return driversList;
        }

        public List<TruckDriversDAO> GetDriversByLocation(string location)
        {
            if (driversList.Count != 0 && driversList.Any(x => string.Equals(x.Location, location, StringComparison.OrdinalIgnoreCase)))
                return driversList
                .Where(x => string.Equals(x.Location, location, StringComparison.OrdinalIgnoreCase)).ToList();
            else
                return new List<TruckDriversDAO>();
        }
        public void GetById(int id)
        {
            //TODO
        }

        public void Insert(TruckDriversDAO driver)
        {
            //TODO
        }
        public void Update(TruckDriversDAO driver)
        {
            //TODO
        }

        public void Delete(int id)
        {
            //TODO
        }
    }
}