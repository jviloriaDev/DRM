using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_WorkFlow_Phases_Complete : BaseEntity
    {
        public int WorkFlow { get; set; }
        public int PhasesId { get; set; }
        public short? Phase_Number { get; set; }
        public string Name { get; set; }
        public short? Phase_Type { get; set; }
        public string Phase_Type_Description { get; set; }
        public short? Type_of_Work_Distribution { get; set; }
        public string Type_of_Work_Distribution_Description { get; set; }
        public short? Type_Flow_Control { get; set; }
        public string Type_Flow_Control_Description { get; set; }
        public short? Phase_Status { get; set; }
        public string Phase_Status_Description { get; set; }

    }
}
