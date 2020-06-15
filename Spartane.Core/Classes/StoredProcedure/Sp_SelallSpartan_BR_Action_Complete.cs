using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_BR_Action_Complete : BaseEntity
    {
        public int ActionId { get; set; }
        public string Description { get; set; }
        public short? Classification { get; set; }
        public string Classification_Description { get; set; }
        public string Implementation_Code { get; set; }

    }
}
