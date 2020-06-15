using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Function : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_Function_Function_Id { get; set; }
        public string Spartan_Function_Description { get; set; }
        public short? Spartan_Function_Function_Type_Id { get; set; }
        public string Spartan_Function_Function_Type_Id_Description { get; set; }
        public int? Spartan_Function_Image { get; set; }
        public string Spartan_Function_Image_Description { get; set; }
        public short? Spartan_Function_Order_Shown { get; set; }
        public short? Spartan_Function_Status { get; set; }
        public string Spartan_Function_Status_Description { get; set; }

    }
}
