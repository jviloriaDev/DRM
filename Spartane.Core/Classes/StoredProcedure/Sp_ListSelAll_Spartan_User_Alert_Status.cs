using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_User_Alert_Status : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_User_Alert_Status_User_Alert_Status_Id { get; set; }
        public string Spartan_User_Alert_Status_Description { get; set; }

    }
}
