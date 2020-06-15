using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_WorkFlow_Type_Work_Distribution_Complete : BaseEntity
    {
        public short Type_of_Work_DistributionId { get; set; }
        public string Description { get; set; }

    }
}
