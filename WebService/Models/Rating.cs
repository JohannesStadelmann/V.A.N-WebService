using System;
using System.ComponentModel.DataAnnotations;

namespace WebService.Models {
    public class Rating {

        [Key]
        public int RatingID { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public int UserRating { get; set; }
        public string Comment { get; set; }

    }
}
