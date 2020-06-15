using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_User : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_User_Id_User { get; set; }
        public string Spartan_User_Name { get; set; }
        public int? Spartan_User_Role { get; set; }
        public string Spartan_User_Role_Description { get; set; }
        public int? Spartan_User_Image { get; set; }
        public string Spartan_User_Image_Description { get; set; }
        public string Spartan_User_Email { get; set; }
        public int? Spartan_User_Status { get; set; }
        public string Spartan_User_Status_Description { get; set; }
        public string Spartan_User_Username { get; set; }
        public string Spartan_User_Password { get; set; }

    }
}
