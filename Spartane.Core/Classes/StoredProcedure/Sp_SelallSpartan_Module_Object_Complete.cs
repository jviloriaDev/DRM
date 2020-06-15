using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Module_Object_Complete : BaseEntity
    {
        public int Module_Object_Id { get; set; }
        public int? Object_Id { get; set; }
        public string Object_Id_Name { get; set; }
        public short Module_Id { get; set; }
        public string Name { get; set; }
        public string Physical_Name { get; set; }
        public string URL { get; set; }
        public short? Order_Shown { get; set; }

    }
}
