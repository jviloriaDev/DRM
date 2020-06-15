using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Report_Presentation_View_Complete : BaseEntity
    {
        public int PresentationViewId { get; set; }
        public string Description { get; set; }
        public int? Presentation_Type { get; set; }
        public string Presentation_Type_Description { get; set; }

    }
}
