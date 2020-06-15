using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_BR_Operation_Detail_Complete : BaseEntity
    {
        public int OperationDetailId { get; set; }
        public int Business_Rule { get; set; }
        public short? Operation { get; set; }
        public string Operation_Description { get; set; }

    }
}
