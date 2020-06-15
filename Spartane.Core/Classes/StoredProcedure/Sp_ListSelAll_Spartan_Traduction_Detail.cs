using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Traduction_Detail : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Traduction_Detail_IdTraductionDetail { get; set; }
        public int Spartan_Traduction_Detail_Spartan_Traduction_Process { get; set; }
        public int? Spartan_Traduction_Detail_Concept { get; set; }
        public string Spartan_Traduction_Detail_Concept_Concept_Description { get; set; }
        public int? Spartan_Traduction_Detail_IdConcept { get; set; }
        public string Spartan_Traduction_Detail_Original_Text { get; set; }
        public string Spartan_Traduction_Detail_Translated_Text { get; set; }

    }
}
