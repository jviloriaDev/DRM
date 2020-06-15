using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_BR_Actions_True_Detail : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_BR_Actions_True_Detail_ActionsTrueDetailId { get; set; }
        public int Spartan_BR_Actions_True_Detail_Business_Rule { get; set; }
        public short? Spartan_BR_Actions_True_Detail_Action_Classification { get; set; }
        public string Spartan_BR_Actions_True_Detail_Action_Classification_Description { get; set; }
        public int? Spartan_BR_Actions_True_Detail_Action { get; set; }
        public string Spartan_BR_Actions_True_Detail_Action_Description { get; set; }
        public short? Spartan_BR_Actions_True_Detail_Action_Result { get; set; }
        public string Spartan_BR_Actions_True_Detail_Action_Result_Description { get; set; }
        public string Spartan_BR_Actions_True_Detail_Parameter_1 { get; set; }
        public string Spartan_BR_Actions_True_Detail_Parameter_2 { get; set; }
        public string Spartan_BR_Actions_True_Detail_Parameter_3 { get; set; }
        public string Spartan_BR_Actions_True_Detail_Parameter_4 { get; set; }
        public string Spartan_BR_Actions_True_Detail_Parameter_5 { get; set; }

    }
}
