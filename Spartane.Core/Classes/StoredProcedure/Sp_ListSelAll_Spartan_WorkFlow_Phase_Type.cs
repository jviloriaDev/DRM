using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_WorkFlow_Phase_Type : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_WorkFlow_Phase_Type_Phase_TypeId { get; set; }
        public string Spartan_WorkFlow_Phase_Type_Description { get; set; }

    }
}
