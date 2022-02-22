using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WQReportService.Data
{   [Keyless]
    public class ScheduledReport_check
    {   
        public int ScheduleID { get; set; }
        public string reportname { get; set; }
        public TimeSpan? reporttime { get; set; }
        public byte? scheduled_dow { get; set; }
        public decimal scheduled_dom { get; set; }
        public decimal scheduled_wom { get; set; }
        public bool BusinessDaysOnly { get; set; }
        public int? UserGroupKey { get; set; }
        public DateTime? rundate { get; set; }
        public DateTime? runtime { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? username { get; set; }
        public string? usergroupname { get; set; }
        public string? recipient { get; set; }
        public int? duration_seconds { get; set; }
        public string send_to { get; set; }
        public int? dayofweek { get; set; }
        public string module { get; set; }
        public int? past_run_time { get; set; }
        public int runToday { get; set; }
        public int? bitdateref { get; set; }

    }
}
