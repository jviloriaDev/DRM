using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Report_Permissions_Complete : BaseEntity
    {
        public int ReportPermissionId { get; set; }
        public int? User_Role { get; set; }
        public int? Report { get; set; }
        public string Report_Report_Name { get; set; }
        public short? Permission_Type { get; set; }
        public string Permission_Type_Description { get; set; }

    }
}
