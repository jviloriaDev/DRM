using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDashboard_Config_Detail : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Dashboard_Config_Detail_Detail_Id { get; set; }
        public int Dashboard_Config_Detail_Dashboard { get; set; }
        public int? Dashboard_Config_Detail_Report_Id { get; set; }
        public string Dashboard_Config_Detail_Report_Name { get; set; }
        public short? Dashboard_Config_Detail_ConfigRow { get; set; }
        public short? Dashboard_Config_Detail_ConfigColumn { get; set; }

    }
}
