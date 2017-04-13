using System;

namespace WebService.ViewModels {
    public class OpenHoursExceptionVM {
        public int OpenHoursExceptionID { get; set; }
        public bool IsOpen { get; set; }
        public DateTime OpeningTime { get; set; }
        public DateTime CloseTime { get; set; }
    }
}
