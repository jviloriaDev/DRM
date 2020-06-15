using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Traduction_Process_Data : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Traduction_Process_Data_Clave { get; set; }
        public int? Spartan_Traduction_Process_Data_Concept { get; set; }
        public string Spartan_Traduction_Process_Data_Concept_Concept_Description { get; set; }
        public string Spartan_Traduction_Process_Data_Name_of_Control { get; set; }
        public string Spartan_Traduction_Process_Data_Original_Text { get; set; }
        public string Spartan_Traduction_Process_Data_Translated_Text { get; set; }
        public int Spartan_Traduction_Process_Data_Spartan_Traduction_Process { get; set; }

    }
}
