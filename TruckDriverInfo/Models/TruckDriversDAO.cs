namespace TruckDriverInfo.Models
{
    public class TruckDriversDAO 
    {
        public long Id { get; set; }      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public long Pincode { get; set; }
        public string VehicleNum { get; set; }
        public string MobileNum { get; set; }

        public TruckDriversDAO(long id,string firstName, string lastName, string location, long pincode , string vehicleNum, string mobileNum)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Location = location;
            this.Pincode = pincode;
            this.VehicleNum = vehicleNum;
            this.MobileNum = mobileNum;
        }
    }
}