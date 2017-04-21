using System;

namespace WebService.ViewModels {
    public class FrequentlyOpenVM {
        public int FrequentlyOpenID { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public int OpeningTime { get; set; }
        public int CloseTime { get; set; }
    }
}
