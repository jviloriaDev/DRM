using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallBusiness_Rule_Creation_Complete : BaseEntity
    {
        public int Key_Business_Rule_Creation { get; set; }
        public int? User { get; set; }
        public string User_Name { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Creation_Hour { get; set; }
        public DateTime? Last_Updated_Date { get; set; }
        public string Last_Updated_Hour { get; set; }
        public int? Time_that_took { get; set; }
        public string Name { get; set; }
        public int? Documentation { get; set; }
        public short? Status { get; set; }
        public string Status_Description { get; set; }
        public int? Complexity { get; set; }
        public string Complexity_Description { get; set; }
        public int? Object { get; set; }
        public int? Attribute { get; set; }
        public bool? AttributeGrid { get; set; }
        public string Implementation_Code { get; set; }

    }
}
