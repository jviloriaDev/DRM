using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Language_Text_Complete : BaseEntity
    {
        public short? System_Language_Id { get; set; }
        public int? Text_Id { get; set; }
        public string Text { get; set; }
        public int Language_Text_Id { get; set; }

    }
}
