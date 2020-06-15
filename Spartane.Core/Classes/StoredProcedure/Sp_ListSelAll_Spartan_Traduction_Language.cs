using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Traduction_Language : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Traduction_Language_IdLanguage { get; set; }
        public string Spartan_Traduction_Language_LanguageT { get; set; }

    }
}
