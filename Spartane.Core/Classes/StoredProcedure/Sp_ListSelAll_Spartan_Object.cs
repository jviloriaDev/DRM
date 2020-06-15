using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Object : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Object_Object_Id { get; set; }
        public string Spartan_Object_Name { get; set; }
        public int? Spartan_Object_Image { get; set; }
        public string Spartan_Object_Image_Description { get; set; }
        public string Spartan_Object_URL { get; set; }
        public string Spartan_Object_Description { get; set; }
        public string Spartan_Object_Tags { get; set; }
        public short? Spartan_Object_Object_Type { get; set; }
        public string Spartan_Object_Object_Type_Description { get; set; }
        public short? Spartan_Object_Status { get; set; }
        public string Spartan_Object_Status_Description { get; set; }

    }
}
