using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Module_Object : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Module_Object_Module_Object_Id { get; set; }
        public int? Spartan_Module_Object_Object_Id { get; set; }
        public string Spartan_Module_Object_Object_Id_Name { get; set; }
        public short Spartan_Module_Object_Module_Id { get; set; }
        public string Spartan_Module_Object_Name { get; set; }
        public string Spartan_Module_Object_Physical_Name { get; set; }
        public string Spartan_Module_Object_URL { get; set; }
        public short? Spartan_Module_Object_Order_Shown { get; set; }

        //Added Spartan_Object_Object_Type to SP 
        public Int16 Spartan_Object_Object_Type { get; set; }
   }
}
