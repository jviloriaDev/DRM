using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Module : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_Module_Module_Id { get; set; }
        public string Spartan_Module_Name { get; set; }
        public short? Spartan_Module_System_Id { get; set; }
        public string Spartan_Module_System_Id_Version { get; set; }
        public short? Spartan_Module_Parent_Module { get; set; }
        public short? Spartan_Module_Order_Shown { get; set; }
        public int? Spartan_Module_Image { get; set; }
        public string Spartan_Module_Image_Description { get; set; }
        public short? Spartan_Module_Object_Config_Id { get; set; }
        public string Spartan_Module_Object_Config_Id_Description { get; set; }
        public string Spartan_Module_Description { get; set; }
        public short? Spartan_Module_Status { get; set; }
        public string Spartan_Module_Status_Description { get; set; }

    }
}
