using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Format_Related_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public int? FormatId { get; set; }
        public int FormatId_FormatId { get; set; }
        public int? FormatId_Related { get; set; }
        public int FormatId_Related_FormatId { get; set; }
        public short? Order { get; set; }

    }
}
