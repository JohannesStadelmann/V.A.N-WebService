using System;

namespace WebService.ViewModels {
    public class RatingVM {
        public int RatingID { get; set; }
        public string Name { get; set; }
        public string GoogleID { get; set; }
        public DateTime Date { get; set; }
        public int UserRating { get; set; }
        public string Comment { get; set; }
    }
}
