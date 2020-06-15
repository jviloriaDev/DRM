using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_BR_History : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_BR_History_Key_History { get; set; }
        public int? Spartan_BR_History_User_logged { get; set; }
        public string Spartan_BR_History_User_logged_Name { get; set; }
        public short? Spartan_BR_History_Status { get; set; }
        public string Spartan_BR_History_Status_Description { get; set; }
        public DateTime? Spartan_BR_History_Change_Date { get; set; }
        public string Spartan_BR_History_Hour_Date { get; set; }
        public int? Spartan_BR_History_Time_elapsed { get; set; }
        public int? Spartan_BR_History_Change_Type { get; set; }
        public string Spartan_BR_History_Change_Type_Description { get; set; }
        public string Spartan_BR_History_Conditions { get; set; }
        public string Spartan_BR_History_Actions_True { get; set; }
        public string Spartan_BR_History_Actions_False { get; set; }
        public int Spartan_BR_History_BusinessRule { get; set; }

    }
}
