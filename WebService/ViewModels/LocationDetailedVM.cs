using System.Collections.Generic;

namespace WebService.ViewModels {
    public class LocationDetailedVM {
        public int LocationID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureURL { get; set; }
        public AddressVM Address { get; set; }
        public TypVM Typ { get; set; }
        public List<MusicGenreVM> MusicGenres { get; set; }
        public List<RatingVM> Ratings { get; set; }
        public List<FrequentlyOpenVM> FrequentlyOpens { get; set; }
        public List<OpenHoursExceptionVM> OpenHoursExceptions { get; set; }

    }
}
