using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Control_Type : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Control_Type_Control_Type_Id { get; set; }
        public int? Spartan_Control_Type_User_Id { get; set; }
        public string Spartan_Control_Type_User_Id_Name { get; set; }
        public int? Spartan_Control_Type_Object { get; set; }
        public string Spartan_Control_Type_Object_Name { get; set; }
        public short? Spartan_Control_Type_Order_Shown { get; set; }

    }
}
