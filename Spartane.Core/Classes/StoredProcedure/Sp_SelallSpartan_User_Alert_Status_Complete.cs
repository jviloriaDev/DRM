using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_User_Alert_Status_Complete : BaseEntity
    {
        public short User_Alert_Status_Id { get; set; }
        public string Description { get; set; }

    }
}
