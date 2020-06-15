using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_BR_Testing : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_BR_Testing_Key_Testing { get; set; }
        public int? Spartan_BR_Testing_User_that_reviewed { get; set; }
        public string Spartan_BR_Testing_User_that_reviewed_Name { get; set; }
        public string Spartan_BR_Testing_Acceptance_Critera { get; set; }
        public bool? Spartan_BR_Testing_It_worked { get; set; }
        public int? Spartan_BR_Testing_Rejection_Reason { get; set; }
        public string Spartan_BR_Testing_Rejection_Reason_Description { get; set; }
        public string Spartan_BR_Testing_Comments { get; set; }
        public int? Spartan_BR_Testing_Evidence { get; set; }
        public string Spartan_BR_Testing_Evidence_Nombre { get; set; }
        public int Spartan_BR_Testing_Business_Rule { get; set; }

    }
}
