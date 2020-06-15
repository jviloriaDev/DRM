using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_BR_Operation_Restrictions_Detail_Complete : BaseEntity
    {
        public int RestrictionId { get; set; }
        public int Action { get; set; }
        public short? Operation { get; set; }
        public string Operation_Description { get; set; }

    }
}
