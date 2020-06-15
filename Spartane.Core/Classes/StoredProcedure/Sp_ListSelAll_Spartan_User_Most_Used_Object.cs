using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_User_Most_Used_Object : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_User_Most_Used_Object_User_Most_Used_Object_Id { get; set; }
        public int? Spartan_User_Most_Used_Object_User_Id { get; set; }
        public string Spartan_User_Most_Used_Object_User_Id_Name { get; set; }
        public int? Spartan_User_Most_Used_Object_Object { get; set; }
        public string Spartan_User_Most_Used_Object_Object_Name { get; set; }
        public short? Spartan_User_Most_Used_Object_Order_Shown { get; set; }

    }
}
