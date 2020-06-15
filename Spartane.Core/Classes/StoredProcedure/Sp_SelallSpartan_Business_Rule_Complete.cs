using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Business_Rule_Complete : BaseEntity
    {
        public int BusinessRuleId { get; set; }
        public DateTime? Registration_Date { get; set; }
        public string Registration_Hour { get; set; }
        public int? User_who_registers { get; set; }
        public string Description { get; set; }
        public int? Object { get; set; }
        public int? Attribute { get; set; }
        public string Implementation_Code { get; set; }
        public int? StatusId { get; set; }
        public bool? AttributeGrid { get; set; }

    }
}
