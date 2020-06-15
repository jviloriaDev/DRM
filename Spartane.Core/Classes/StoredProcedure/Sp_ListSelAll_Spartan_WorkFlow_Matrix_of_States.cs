using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_WorkFlow_Matrix_of_States : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow { get; set; }
        public int Spartan_WorkFlow_Matrix_of_States_Matrix_of_StatesId { get; set; }
        public int? Spartan_WorkFlow_Matrix_of_States_Phase { get; set; }
        public string Spartan_WorkFlow_Matrix_of_States_Phase_Name { get; set; }
        public int? Spartan_WorkFlow_Matrix_of_States_State { get; set; }
        public string Spartan_WorkFlow_Matrix_of_States_State_Name { get; set; }
        public int? Spartan_WorkFlow_Matrix_of_States_Attribute { get; set; }
        public string Spartan_WorkFlow_Matrix_of_States_Attribute_Logical_Name { get; set; }
        public bool? Spartan_WorkFlow_Matrix_of_States_Visible { get; set; }
        public bool? Spartan_WorkFlow_Matrix_of_States_Required { get; set; }
        public bool? Spartan_WorkFlow_Matrix_of_States_Read_Only { get; set; }
        public string Spartan_WorkFlow_Matrix_of_States_Label { get; set; }
        public string Spartan_WorkFlow_Matrix_of_States_Default_Value { get; set; }
        public string Spartan_WorkFlow_Matrix_of_States_Help_Text { get; set; }

    }
}
