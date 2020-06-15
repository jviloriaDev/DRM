using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Module_Object_Method_Complete : BaseEntity
    {
        public short Module_Object_Method_Id { get; set; }
        public int? Object_Id { get; set; }
        public string Object_Id_Name { get; set; }
        public short? Order_Shown { get; set; }
        public short Spartan_Module { get; set; }

    }
}
