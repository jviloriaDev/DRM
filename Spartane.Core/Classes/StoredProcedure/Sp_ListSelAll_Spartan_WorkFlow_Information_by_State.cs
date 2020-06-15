using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_WorkFlow_Information_by_State : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_WorkFlow_Information_by_State_Spartan_WorkFlow { get; set; }
        public int Spartan_WorkFlow_Information_by_State_Information_by_StateId { get; set; }
        public int? Spartan_WorkFlow_Information_by_State_Phase { get; set; }
        public string Spartan_WorkFlow_Information_by_State_Phase_Name { get; set; }
        public int? Spartan_WorkFlow_Information_by_State_State { get; set; }
        public string Spartan_WorkFlow_Information_by_State_State_Name { get; set; }
        public int? Spartan_WorkFlow_Information_by_State_Folder { get; set; }
        public string Spartan_WorkFlow_Information_by_State_Folder_Group_Name { get; set; }
        public bool? Spartan_WorkFlow_Information_by_State_Visible { get; set; }
        public bool? Spartan_WorkFlow_Information_by_State_Read_Only { get; set; }
        public bool? Spartan_WorkFlow_Information_by_State_Required { get; set; }
        public string Spartan_WorkFlow_Information_by_State_Label { get; set; }

    }
}
