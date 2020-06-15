using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Menu_Orientation : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_Menu_Orientation_System_Menu_Orientation_Id { get; set; }
        public string Spartan_Menu_Orientation_Description { get; set; }

    }
}
