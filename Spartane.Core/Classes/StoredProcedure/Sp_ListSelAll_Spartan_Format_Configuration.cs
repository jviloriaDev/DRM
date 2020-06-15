using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Format_Configuration : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Format_Configuration_Format { get; set; }
        public string Spartan_Format_Configuration_Query_To_Fill_Fields { get; set; }
        public string Spartan_Format_Configuration_Filter_to_Show { get; set; }

    }
}
