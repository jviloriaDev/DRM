using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_User_Object_Method_Config_Complete : BaseEntity
    {
        public int User_Object_Method_Config_Id { get; set; }
        public int? User_Id { get; set; }
        public string User_Id_Name { get; set; }
        public short? Module_Id { get; set; }
        public string Module_Id_Name { get; set; }
        public int? Object_Id { get; set; }
        public string Object_Id_Name { get; set; }
        public int? Characteristic { get; set; }
        public string Characteristic_Description { get; set; }
        public int? Numeric_Value { get; set; }
        public string Text_Value { get; set; }

    }
}
