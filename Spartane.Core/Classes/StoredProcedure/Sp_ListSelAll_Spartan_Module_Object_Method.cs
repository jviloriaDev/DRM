using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Module_Object_Method : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_Module_Object_Method_Module_Object_Method_Id { get; set; }
        public int? Spartan_Module_Object_Method_Object_Id { get; set; }
        public string Spartan_Module_Object_Method_Object_Id_Name { get; set; }
        public short? Spartan_Module_Object_Method_Order_Shown { get; set; }
        public short Spartan_Module_Object_Method_Spartan_Module { get; set; }

    }
}
