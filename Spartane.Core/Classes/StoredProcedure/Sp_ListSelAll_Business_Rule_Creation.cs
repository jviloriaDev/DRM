using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllBusiness_Rule_Creation : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Business_Rule_Creation_Key_Business_Rule_Creation { get; set; }
        public int? Business_Rule_Creation_User { get; set; }
        public string Business_Rule_Creation_User_Name { get; set; }
        public DateTime? Business_Rule_Creation_Creation_Date { get; set; }
        public string Business_Rule_Creation_Creation_Hour { get; set; }
        public DateTime? Business_Rule_Creation_Last_Updated_Date { get; set; }
        public string Business_Rule_Creation_Last_Updated_Hour { get; set; }
        public int? Business_Rule_Creation_Time_that_took { get; set; }
        public string Business_Rule_Creation_Name { get; set; }
        public int? Business_Rule_Creation_Documentation { get; set; }
        public string Business_Rule_Creation_Documentation_Nombre { get; set; }
        public short? Business_Rule_Creation_Status { get; set; }
        public string Business_Rule_Creation_Status_Description { get; set; }
        public int? Business_Rule_Creation_Complexity { get; set; }
        public string Business_Rule_Creation_Complexity_Description { get; set; }
        //Implementation_Code

        public int? Business_Rule_Creation_Attribute { get; set; }
        public int? Business_Rule_Creation_Object { get; set; }
        public bool? Business_Rule_Creation_AttributeGrid { get; set; }
        public string Business_Rule_Creation_Implementation_Code { get; set; }

    }
}
