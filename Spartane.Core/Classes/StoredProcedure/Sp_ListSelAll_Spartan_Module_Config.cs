using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Module_Config : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_Module_Config_Module_Config_Id { get; set; }
        public short? Spartan_Module_Config_Order_Type { get; set; }
        public string Spartan_Module_Config_Order_Type_Description { get; set; }

    }
}
