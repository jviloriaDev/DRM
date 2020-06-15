using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Object_Method : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_Object_Method_Module_Id { get; set; }
        public int? Spartan_Object_Method_Object_Id { get; set; }
        public string Spartan_Object_Method_Object_Id_Name { get; set; }
        public string Spartan_Object_Method_Name { get; set; }
        public string Spartan_Object_Method_Physical_Name { get; set; }
        public string Spartan_Object_Method_URL { get; set; }
        public short? Spartan_Object_Method_Method_Type { get; set; }
        public string Spartan_Object_Method_Method_Type_Description { get; set; }
        public string Spartan_Object_Method_Scope { get; set; }
        public string Spartan_Object_Method_Tags { get; set; }
        public int? Spartan_Object_Method_Image { get; set; }
        public string Spartan_Object_Method_Image_Description { get; set; }
        public short? Spartan_Object_Method_Status { get; set; }
        public string Spartan_Object_Method_Status_Description { get; set; }
        public int Spartan_Object_Method_Object_Method_Id { get; set; }

    }
}
