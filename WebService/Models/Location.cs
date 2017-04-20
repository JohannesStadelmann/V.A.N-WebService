using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Models {
    public class Location {

        [Key]
        public int LocationID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureURL { get; set; }
        public Address Address { get; set; }
        public Typ Typ { get; set; }
        public List<MusicGenre> MusicGenres { get; set; }
        public List<Rating> Ratings { get; set; }
        public List<FrequentlyOpen> FrequentlyOpens { get; set; }
        public List<OpenHoursException> OpenHoursExceptions { get; set; }

    }
}
