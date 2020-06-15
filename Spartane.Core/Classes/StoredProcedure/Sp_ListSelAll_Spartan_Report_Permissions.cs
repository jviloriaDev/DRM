using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Report_Permissions : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Report_Permissions_ReportPermissionId { get; set; }
        public int? Spartan_Report_Permissions_User_Role { get; set; }
        public int? Spartan_Report_Permissions_Report { get; set; }
        public string Spartan_Report_Permissions_Report_Report_Name { get; set; }
        public short? Spartan_Report_Permissions_Permission_Type { get; set; }
        public string Spartan_Report_Permissions_Permission_Type_Description { get; set; }

    }
}
