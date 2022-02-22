using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WQReportService.Data
{
    public class DataAccess
    {
        private readonly Context _context;
        public DataAccess(Context context)
        {
            _context = context;
        }
        public ScheduledReport_check Get() {
            var scheduleReportCheck = new ScheduledReport_check();

            scheduleReportCheck = _context.ScheduledReport_check.FirstOrDefault((o) => o.reportname == "EK - AR Invoices"  );
            
            return scheduleReportCheck;
        }
        public List<ScheduledReport_check> GetList()
        {
            var scheduleReportCheck = new List<ScheduledReport_check>();

            scheduleReportCheck = _context.ScheduledReport_check.Where((o) => o.reportname == "AP Trial Balance").OrderBy((a) => a.ScheduleID).ToList();
            
            return scheduleReportCheck;
        }
    }
}
