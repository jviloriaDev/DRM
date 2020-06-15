using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDashboard_Status : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Dashboard_Status_Status_Id { get; set; }
        public string Dashboard_Status_Description { get; set; }

    }
}
