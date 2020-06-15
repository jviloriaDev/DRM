using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_User_Favorite_List : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_User_Favorite_List_User_Favorite_List_Id { get; set; }
        public int? Spartan_User_Favorite_List_User_Id { get; set; }
        public string Spartan_User_Favorite_List_User_Id_Name { get; set; }
        public int? Spartan_User_Favorite_List_Object { get; set; }
        public string Spartan_User_Favorite_List_Object_Name { get; set; }
        public short? Spartan_User_Favorite_List_Order_Shown { get; set; }

    }
}
