using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Menu_Style : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_Menu_Style_Menu_Style_Id { get; set; }
        public string Spartan_Menu_Style_Description { get; set; }

    }
}
