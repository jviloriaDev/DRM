using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Traduction_Process_Complete : BaseEntity
    {
        public int IdTraduction { get; set; }
        public int? LanguageT { get; set; }
        public string LanguageT_LanguageT { get; set; }
        public int? Object_Type { get; set; }
        public string Object_Type_Object_Type_Description { get; set; }
        public int? ObjectT { get; set; }
        public string ObjectT_Name { get; set; }

    }
}
