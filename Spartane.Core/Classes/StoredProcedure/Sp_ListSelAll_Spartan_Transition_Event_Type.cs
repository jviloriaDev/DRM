using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Transition_Event_Type : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Transition_Event_Type_Transition_Event_Type_Id { get; set; }
        public string Spartan_Transition_Event_Type_Description { get; set; }

    }
}
