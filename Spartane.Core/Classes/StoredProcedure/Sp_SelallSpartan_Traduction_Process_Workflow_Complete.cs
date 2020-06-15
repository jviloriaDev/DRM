using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Traduction_Process_Workflow_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public int? Concept { get; set; }
        public string Concept_Concept_Description { get; set; }
        public int? ID_of_Step { get; set; }
        public string Original_Text { get; set; }
        public string Translated_Text { get; set; }
        public int Process { get; set; }

    }
}
