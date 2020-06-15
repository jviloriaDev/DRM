using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_BR_Modifications_Log_Complete : BaseEntity
    {
        public int ModificationId { get; set; }
        public int Business_Rule { get; set; }
        public DateTime? Modification_Date { get; set; }
        public string Modification_Hour { get; set; }
        public int? Modification_User { get; set; }
        public string Comments { get; set; }
        public string Implementation_Code { get; set; }

    }
}
