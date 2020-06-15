using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_BR_Attribute_Restrictions_Detail_Complete : BaseEntity
    {
        public int RestrictionId { get; set; }
        public int Action { get; set; }
        public int? Attribute_Type { get; set; }
        public string Attribute_Type_Description { get; set; }
        public short? Control_Type { get; set; }
        public string Control_Type_Description { get; set; }

    }
}
