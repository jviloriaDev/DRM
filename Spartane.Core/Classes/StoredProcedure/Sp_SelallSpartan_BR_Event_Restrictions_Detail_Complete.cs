using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_BR_Event_Restrictions_Detail_Complete : BaseEntity
    {
        public int RestrictionId { get; set; }
        public int Action { get; set; }
        public short? Process_Event { get; set; }
        public string Process_Event_Description { get; set; }

    }
}
