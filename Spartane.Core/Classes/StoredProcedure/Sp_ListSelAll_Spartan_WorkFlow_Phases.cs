using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_WorkFlow_Phases : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_WorkFlow_Phases_WorkFlow { get; set; }
        public int Spartan_WorkFlow_Phases_PhasesId { get; set; }
        public short? Spartan_WorkFlow_Phases_Phase_Number { get; set; }
        public string Spartan_WorkFlow_Phases_Name { get; set; }
        public short? Spartan_WorkFlow_Phases_Phase_Type { get; set; }
        public string Spartan_WorkFlow_Phases_Phase_Type_Description { get; set; }
        public short? Spartan_WorkFlow_Phases_Type_of_Work_Distribution { get; set; }
        public string Spartan_WorkFlow_Phases_Type_of_Work_Distribution_Description { get; set; }
        public short? Spartan_WorkFlow_Phases_Type_Flow_Control { get; set; }
        public string Spartan_WorkFlow_Phases_Type_Flow_Control_Description { get; set; }
        public short? Spartan_WorkFlow_Phases_Phase_Status { get; set; }
        public string Spartan_WorkFlow_Phases_Phase_Status_Description { get; set; }

    }
}
