using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_User_Quicklink_Complete : BaseEntity
    {
        public int User_Quicklink_Id { get; set; }
        public int? User_Id { get; set; }
        public string User_Id_Name { get; set; }
        public int? Object { get; set; }
        public string Object_Name { get; set; }
        public short? Order_Shown { get; set; }
        public short? Method_Type { get; set; }
        public string Method_Type_Description { get; set; }
        public string Description { get; set; }
        public int? Atribute_Id { get; set; }
        public int? Control_Type { get; set; }
        public int Control_Type_User_Id { get; set; }

    }
}
