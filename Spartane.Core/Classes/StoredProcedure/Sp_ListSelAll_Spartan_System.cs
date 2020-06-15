using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_System : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_System_System_Id { get; set; }
        public string Spartan_System_Version { get; set; }
        public int? Spartan_System_System_Image { get; set; }
        public string Spartan_System_System_Image_Description { get; set; }
        public int? Spartan_System_Customer_Image { get; set; }
        public string Spartan_System_Customer_Image_Description { get; set; }
        public int? Spartan_System_Developer_Image { get; set; }
        public string Spartan_System_Developer_Image_Description { get; set; }

    }
}
