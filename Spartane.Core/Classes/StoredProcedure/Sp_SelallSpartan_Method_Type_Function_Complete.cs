using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Method_Type_Function_Complete : BaseEntity
    {
        public short Method_Type_Function_Id { get; set; }
        public short? Function_Id { get; set; }
        public string Function_Id_Description { get; set; }
        public short Spartan_Method_Type { get; set; }

    }
}
