using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_WorkFlow_Matrix_of_States_Complete : BaseEntity
    {
        public int Spartan_WorkFlow { get; set; }
        public int Matrix_of_StatesId { get; set; }
        public int? Phase { get; set; }
        public string Phase_Name { get; set; }
        public int? State { get; set; }
        public string State_Name { get; set; }
        public int? Attribute { get; set; }
        public string Attribute_Logical_Name { get; set; }
        public bool? Visible { get; set; }
        public bool? Required { get; set; }
        public bool? Read_Only { get; set; }
        public string Label { get; set; }
        public string Default_Value { get; set; }
        public string Help_Text { get; set; }

    }
}
