using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Traduction_Concept_Type : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Traduction_Concept_Type_IdConcept { get; set; }
        public string Spartan_Traduction_Concept_Type_Concept_Description { get; set; }

    }
}
