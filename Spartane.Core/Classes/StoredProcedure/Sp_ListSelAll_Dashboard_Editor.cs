using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDashboard_Editor : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Dashboard_Editor_Dashboard_Id { get; set; }
        public DateTime? Dashboard_Editor_Registration_Date { get; set; }
        public int? Dashboard_Editor_Registration_User { get; set; }
        public string Dashboard_Editor_Registration_User_Name { get; set; }
        public string Dashboard_Editor_Name { get; set; }
        public int? Dashboard_Editor_Dashboard_Template { get; set; }
        public string Dashboard_Editor_Dashboard_Template_Description { get; set; }
        public bool? Dashboard_Editor_Show_in_Home { get; set; }
        public short? Dashboard_Editor_Status { get; set; }
        public string Dashboard_Editor_Status_Description { get; set; }
        public int? Dashboard_Editor_Spartan_Object { get; set; }

    }
}
