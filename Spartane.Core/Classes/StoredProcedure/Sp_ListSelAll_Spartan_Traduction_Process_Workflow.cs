using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Traduction_Process_Workflow : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Traduction_Process_Workflow_Clave { get; set; }
        public int? Spartan_Traduction_Process_Workflow_Concept { get; set; }
        public string Spartan_Traduction_Process_Workflow_Concept_Concept_Description { get; set; }
        public int? Spartan_Traduction_Process_Workflow_ID_of_Step { get; set; }
        public string Spartan_Traduction_Process_Workflow_Original_Text { get; set; }
        public string Spartan_Traduction_Process_Workflow_Translated_Text { get; set; }
        public int Spartan_Traduction_Process_Workflow_Process { get; set; }

    }
}
