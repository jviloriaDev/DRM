using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_System_Layout : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_System_Layout_System_Layout_Id { get; set; }
        public short? Spartan_System_Layout_System_Id { get; set; }
        public string Spartan_System_Layout_System_Id_Version { get; set; }
        public short? Spartan_System_Layout_Menu_Style_Id { get; set; }
        public string Spartan_System_Layout_Menu_Style_Id_Description { get; set; }
        public string Spartan_System_Layout_Description { get; set; }
        public string Spartan_System_Layout_Layout_URL { get; set; }
        public string Spartan_System_Layout_Class_URL { get; set; }
        public short? Spartan_System_Layout_Orientation { get; set; }
        public string Spartan_System_Layout_Orientation_Description { get; set; }
        public short? Spartan_System_Layout_Layout_Status { get; set; }
        public string Spartan_System_Layout_Layout_Status_Description { get; set; }

    }
}
