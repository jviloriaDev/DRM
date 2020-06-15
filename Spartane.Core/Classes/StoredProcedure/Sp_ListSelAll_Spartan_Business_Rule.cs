using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Business_Rule : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Business_Rule_BusinessRuleId { get; set; }
        public DateTime? Spartan_Business_Rule_Registration_Date { get; set; }
        public string Spartan_Business_Rule_Registration_Hour { get; set; }
        public int? Spartan_Business_Rule_User_who_registers { get; set; }
        public string Spartan_Business_Rule_Description { get; set; }
        public int? Spartan_Business_Rule_Object { get; set; }
        public int? Spartan_Business_Rule_Attribute { get; set; }
        public string Spartan_Business_Rule_Implementation_Code { get; set; }
        public int? Spartan_Business_Rule_StatusId { get; set; }
        public bool? Spartan_Business_Rule_AttributeGrid { get; set; }

    }
}
