using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_User_Rule_Module_Complete : BaseEntity
    {
        public short User_Rule_Module_Id { get; set; }
        public short? Module_Id { get; set; }
        public string Module_Id_Name { get; set; }
        public short? Order_Shown { get; set; }
        public int Spartan_User_Role { get; set; }

    }
}
