using System;

namespace WebService.ViewModels {
    public class RatingVM {
        public int RatingID { get; set; }
        public UserVM User { get; set; }
        public DateTime Date { get; set; }
        public int UserRating { get; set; }
        public string Comment { get; set; }
    }
}
