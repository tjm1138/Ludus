using System.Collections.Generic;

namespace Ludus.Models
{
    public class PageWithSelectList
    {
        public Dictionary<int, string> DaysOfWeek { get; set; }
        public int DayOfWeek { get; set; }

        public PageWithSelectList()
        {
            this.DaysOfWeek = new Dictionary<int, string>
                                    {
                                        {1, "Sunday"},
                                        {2, "Monday"},
                                        {3, "Tuesday"},
                                        {4, "Wednesday"},
                                        {5, "Thursday"},
                                        {6, "Friday"},
                                        {7, "Saturday"}
                                    };
        }
    }
}