using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Models {
    public class Address {

        [Key]
        public int AddressID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNo { get; set; }
        public long GPSLatitude { get; set; }
        public long GPSLongitude { get; set; }

    }
}
