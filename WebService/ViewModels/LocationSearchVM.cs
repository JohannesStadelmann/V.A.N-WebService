using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.ViewModels {
    public class LocationSearchVM {

        public string Location { get; set; }
        public string City { get; set; }
        public string Typ { get; set; }
        public string MusicGenre { get; set; }
        public bool IsOpen { get; set; }

    }
}