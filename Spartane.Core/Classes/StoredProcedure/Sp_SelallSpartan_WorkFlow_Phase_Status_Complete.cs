using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_WorkFlow_Phase_Status_Complete : BaseEntity
    {
        public short StatusId { get; set; }
        public string Description { get; set; }

    }
}
