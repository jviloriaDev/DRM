using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Method_Type_Function : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_Method_Type_Function_Method_Type_Function_Id { get; set; }
        public short? Spartan_Method_Type_Function_Function_Id { get; set; }
        public string Spartan_Method_Type_Function_Function_Id_Description { get; set; }
        public short Spartan_Method_Type_Function_Spartan_Method_Type { get; set; }

    }
}
