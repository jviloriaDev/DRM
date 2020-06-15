using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Module_Complete : BaseEntity
    {
        public short Module_Id { get; set; }
        public string Name { get; set; }
        public short? System_Id { get; set; }
        public string System_Id_Version { get; set; }
        public short? Parent_Module { get; set; }
        public short? Order_Shown { get; set; }
        public int? Image { get; set; }
        public string Image_Description { get; set; }
        public short? Object_Config_Id { get; set; }
        public string Object_Config_Id_Description { get; set; }
        public string Description { get; set; }
        public short? Status { get; set; }
        public string Status_Description { get; set; }

    }
}
