using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Event_Type_Complete : BaseEntity
    {
        public short Event_Type_Id { get; set; }
        public string Description { get; set; }

    }
}
