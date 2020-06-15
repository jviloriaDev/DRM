using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_WorkFlow_State_Complete : BaseEntity
    {
        public int Spartan_WorkFlow { get; set; }
        public int StateId { get; set; }
        public int? Phase { get; set; }
        public string Phase_Name { get; set; }
        public int? Attribute { get; set; }
        public string Attribute_Logical_Name { get; set; }
        public int? State_Code { get; set; }
        public string Name { get; set; }
        public int? Value { get; set; }
        public string Text { get; set; }

    }
}
