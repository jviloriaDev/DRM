using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_BR_Scope_Detail : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_BR_Scope_Detail_ScopeDetailId { get; set; }
        public int Spartan_BR_Scope_Detail_Business_Rule { get; set; }
        public short? Spartan_BR_Scope_Detail_Scope { get; set; }
        public string Spartan_BR_Scope_Detail_Scope_Description { get; set; }

    }
}
