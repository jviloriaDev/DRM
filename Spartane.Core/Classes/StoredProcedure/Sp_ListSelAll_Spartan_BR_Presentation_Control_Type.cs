using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_BR_Presentation_Control_Type : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_BR_Presentation_Control_Type_PresentationControlTypeId { get; set; }
        public string Spartan_BR_Presentation_Control_Type_Description { get; set; }

    }
}
