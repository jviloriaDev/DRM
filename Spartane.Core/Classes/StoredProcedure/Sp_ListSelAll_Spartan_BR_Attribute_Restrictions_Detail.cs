using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_BR_Attribute_Restrictions_Detail : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_BR_Attribute_Restrictions_Detail_RestrictionId { get; set; }
        public int Spartan_BR_Attribute_Restrictions_Detail_Action { get; set; }
        public int? Spartan_BR_Attribute_Restrictions_Detail_Attribute_Type { get; set; }
        public string Spartan_BR_Attribute_Restrictions_Detail_Attribute_Type_Description { get; set; }
        public short? Spartan_BR_Attribute_Restrictions_Detail_Control_Type { get; set; }
        public string Spartan_BR_Attribute_Restrictions_Detail_Control_Type_Description { get; set; }

    }
}
