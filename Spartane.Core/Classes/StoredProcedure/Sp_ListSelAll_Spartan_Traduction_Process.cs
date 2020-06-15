using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Traduction_Process : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Traduction_Process_IdTraduction { get; set; }
        public int? Spartan_Traduction_Process_LanguageT { get; set; }
        public string Spartan_Traduction_Process_LanguageT_LanguageT { get; set; }
        public int? Spartan_Traduction_Process_Object_Type { get; set; }
        public string Spartan_Traduction_Process_Object_Type_Object_Type_Description { get; set; }
        public int? Spartan_Traduction_Process_ObjectT { get; set; }
        public string Spartan_Traduction_Process_ObjectT_Name { get; set; }

    }
}
