using System;

namespace WebService.ViewModels {
    public class FrequentlyOpenVM {
        public int FrequentlyOpenID { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan OpeningTime { get; set; }
        public TimeSpan CloseTime { get; set; }
    }
}
