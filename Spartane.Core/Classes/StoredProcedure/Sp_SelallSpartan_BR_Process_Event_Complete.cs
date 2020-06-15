using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_BR_Process_Event_Complete : BaseEntity
    {
        public short ProcessEventId { get; set; }
        public string Description { get; set; }

    }
}
