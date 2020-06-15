using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallTemplate_Dashboard_Detail_Complete : BaseEntity
    {
        public int Detail_Id { get; set; }
        public int Template { get; set; }
        public short? Row_Number { get; set; }
        public short? Columns { get; set; }

    }
}
