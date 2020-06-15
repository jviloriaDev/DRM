using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Function_Event : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_Function_Event_Function_Event_Id { get; set; }
        public short? Spartan_Function_Event_Event_Type_Id { get; set; }
        public string Spartan_Function_Event_Event_Type_Id_Description { get; set; }
        public short Spartan_Function_Event_Spartan_Function { get; set; }

    }
}
