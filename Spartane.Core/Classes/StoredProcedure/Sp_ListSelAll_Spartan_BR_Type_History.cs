using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_BR_Type_History : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_BR_Type_History_Key_Type_History { get; set; }
        public string Spartan_BR_Type_History_Description { get; set; }

    }
}
