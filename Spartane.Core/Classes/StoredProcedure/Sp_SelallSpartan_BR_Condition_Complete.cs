using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_BR_Condition_Complete : BaseEntity
    {
        public short ConditionId { get; set; }
        public string Description { get; set; }
        public string Implementation_Code { get; set; }

    }
}
