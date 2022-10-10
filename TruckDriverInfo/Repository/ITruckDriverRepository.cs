using TruckDriverInfo.Models;

namespace TruckDriverInfo.Repository
{
    public interface ITruckDriverRepository
    {
        IList<TruckDriversDAO> GetAll();
        //TruckDriversDAO GetById(int id);
        void GetById(int id);
        void Insert(TruckDriversDAO driver);
        void Update(TruckDriversDAO driver);
        void Delete(int id);
        List<TruckDriversDAO> GetDriversByLocation(string location);

    }
}
