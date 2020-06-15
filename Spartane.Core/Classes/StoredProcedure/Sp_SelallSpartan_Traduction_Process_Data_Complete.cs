using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Traduction_Process_Data_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public int? Concept { get; set; }
        public string Concept_Concept_Description { get; set; }
        public string Name_of_Control { get; set; }
        public string Original_Text { get; set; }
        public string Translated_Text { get; set; }
        public int Spartan_Traduction_Process { get; set; }

    }
}
