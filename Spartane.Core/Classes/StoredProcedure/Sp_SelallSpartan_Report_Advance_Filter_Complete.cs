using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Report_Advance_Filter_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public int? Report { get; set; }
        public string Report_Report_Name { get; set; }
        public int? AttributeId { get; set; }
        public string AttributeId_Physical_Name { get; set; }
        public string Defect_Value_From { get; set; }
        public string Defect_Value_To { get; set; }
        public string CampoQuery { get; set; }
        public bool Visible { get; set; }

    }
}
