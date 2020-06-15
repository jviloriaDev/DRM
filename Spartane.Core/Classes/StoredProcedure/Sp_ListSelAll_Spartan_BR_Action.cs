using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_BR_Action : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_BR_Action_ActionId { get; set; }
        public string Spartan_BR_Action_Description { get; set; }
        public short? Spartan_BR_Action_Classification { get; set; }
        public string Spartan_BR_Action_Classification_Description { get; set; }
        public string Spartan_BR_Action_Implementation_Code { get; set; }

    }
}
