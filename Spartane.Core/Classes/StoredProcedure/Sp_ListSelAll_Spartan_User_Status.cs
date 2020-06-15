using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_User_Status : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_User_Status_User_Status_Id { get; set; }
        public string Spartan_User_Status_Description { get; set; }

    }
}
