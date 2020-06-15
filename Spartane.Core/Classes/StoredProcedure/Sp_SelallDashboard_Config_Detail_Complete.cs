using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDashboard_Config_Detail_Complete : BaseEntity
    {
        public int Detail_Id { get; set; }
        public int Dashboard { get; set; }
        public int? Report_Id { get; set; }
        public string Report_Name { get; set; }
        public short? ConfigRow { get; set; }
        public short? ConfigColumn { get; set; }

    }
}
