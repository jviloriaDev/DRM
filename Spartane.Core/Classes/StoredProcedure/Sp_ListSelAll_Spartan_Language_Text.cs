using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Language_Text : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short? Spartan_Language_Text_System_Language_Id { get; set; }
        public int? Spartan_Language_Text_Text_Id { get; set; }
        public string Spartan_Language_Text_Text { get; set; }
        public int Spartan_Language_Text_Language_Text_Id { get; set; }

    }
}
