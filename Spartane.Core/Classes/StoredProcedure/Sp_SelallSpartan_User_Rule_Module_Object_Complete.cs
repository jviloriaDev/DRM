using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_User_Rule_Module_Object_Complete : BaseEntity
    {
        public int User_Rule_Module_Object_Id { get; set; }
        public short? Module_Id { get; set; }
        public string Module_Id_Name { get; set; }
        public int? Object_Id { get; set; }
        public string Object_Id_Name { get; set; }
        public short? Order_Shown { get; set; }
        public int Spartan_User_Role { get; set; }

    }
}
