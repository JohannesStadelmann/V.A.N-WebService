using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Models {
    public class FrequentlyOpen {

        [Key]
        public int FrequentlyOpenID { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public int OpeningTime { get; set; }
        public int CloseTime { get; set; }
    }
}
