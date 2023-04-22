using rfidtag.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace rfidtag.Models
{
    public class Supply
    {
        [Key]
        public int Id { get; set; }
        public int RfidNo { get; set; }
        public string Owner { get; set; }
        public Location Location { get; set; }
        public Gender Gender { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Contact { get; set; }
        public DateTime BirthDate { get; set; }
        public HealthStatus HealthStatus { get; set; }
    }
}
