using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllTemplate_Dashboard_Detail : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Template_Dashboard_Detail_Detail_Id { get; set; }
        public int Template_Dashboard_Detail_Template { get; set; }
        public short? Template_Dashboard_Detail_Row_Number { get; set; }
        public short? Template_Dashboard_Detail_Columns { get; set; }

    }
}
