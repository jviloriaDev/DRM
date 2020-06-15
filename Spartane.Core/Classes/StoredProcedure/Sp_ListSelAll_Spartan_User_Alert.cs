using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_User_Alert : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_User_Alert_User__Alert_Id { get; set; }
        public int? Spartan_User_Alert_User_Id { get; set; }
        public string Spartan_User_Alert_User_Id_Name { get; set; }
        public short? Spartan_User_Alert_Alert_Type { get; set; }
        public string Spartan_User_Alert_Alert_Type_Description { get; set; }
        public string Spartan_User_Alert_Description { get; set; }
        public string Spartan_User_Alert_URL { get; set; }
        public short? Spartan_User_Alert_Status { get; set; }
        public string Spartan_User_Alert_Status_Description { get; set; }

    }
}
