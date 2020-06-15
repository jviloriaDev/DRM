using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_BR_Process_Event_Detail_Complete : BaseEntity
    {
        public int ProcessEventDetailId { get; set; }
        public int Business_Rule { get; set; }
        public short? Process_Event { get; set; }
        public string Process_Event_Description { get; set; }

    }
}
