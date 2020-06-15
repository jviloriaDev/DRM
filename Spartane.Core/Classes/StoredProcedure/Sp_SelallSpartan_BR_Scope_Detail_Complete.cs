using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_BR_Scope_Detail_Complete : BaseEntity
    {
        public int ScopeDetailId { get; set; }
        public int Business_Rule { get; set; }
        public short? Scope { get; set; }
        public string Scope_Description { get; set; }

    }
}
