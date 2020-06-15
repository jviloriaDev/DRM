using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Function_Event_Complete : BaseEntity
    {
        public short Function_Event_Id { get; set; }
        public short? Event_Type_Id { get; set; }
        public string Event_Type_Id_Description { get; set; }
        public short Spartan_Function { get; set; }

    }
}
