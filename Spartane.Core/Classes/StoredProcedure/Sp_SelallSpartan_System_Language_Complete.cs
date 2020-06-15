using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_System_Language_Complete : BaseEntity
    {
        public short System_Language_Id { get; set; }
        public string Resource_File { get; set; }
        public string Language { get; set; }
        public bool? Initial { get; set; }

    }
}
