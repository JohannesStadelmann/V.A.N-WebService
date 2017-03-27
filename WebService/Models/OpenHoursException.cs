using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Models {
    public class OpenHoursException {

        [Key]
        public int OpenHoursExceptionID { get; set; }
        public bool IsOpen { get; set; }
        public DateTime OpeningTime { get; set; }
        public DateTime CloseTime { get; set; }
    }
}
