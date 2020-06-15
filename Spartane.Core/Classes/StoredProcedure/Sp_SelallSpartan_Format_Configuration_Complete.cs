using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Format_Configuration_Complete : BaseEntity
    {
        public int Format { get; set; }
        public string Query_To_Fill_Fields { get; set; }
        public string Filter_to_Show { get; set; }

    }
}
