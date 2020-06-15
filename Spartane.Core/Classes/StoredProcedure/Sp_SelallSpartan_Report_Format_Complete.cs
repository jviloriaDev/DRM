using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Report_Format_Complete : BaseEntity
    {
        public int FormatId { get; set; }
        public string Description { get; set; }
        public string Format_Mask { get; set; }

    }
}
