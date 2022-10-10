using System.ComponentModel.DataAnnotations;

namespace TruckDriverInfo.Models
{
    public class TruckDriversDTO
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Location { get; set; }
        public long Pincode { get; set; }
        public TruckDriversDTO(long id, string firstName, string lastName, string location, long pincode)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Location = location;
            this.Pincode = pincode;
        }
    }
}
