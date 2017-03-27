using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Models {
    public class Rating {

        [Key]
        public int RatingID { get; set; }
        public string Name { get; set; }
        public string GoogleID { get; set; }
        public DateTime Date { get; set; }
        public int UserRating { get; set; }
        public string Comment { get; set; }

    }
}
