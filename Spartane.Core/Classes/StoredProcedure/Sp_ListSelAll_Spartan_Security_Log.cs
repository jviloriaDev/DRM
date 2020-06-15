using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Security_Log : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Security_Log_Security_Log_Id { get; set; }
        public DateTime? Spartan_Security_Log_Log_Date { get; set; }
        public int? Spartan_Security_Log_User_Role_Id { get; set; }
        public string Spartan_Security_Log_User_Role_Id_Description { get; set; }
        public int? Spartan_Security_Log_User_Id { get; set; }
        public string Spartan_Security_Log_User_Id_Name { get; set; }
        public string Spartan_Security_Log_IP_Address_Source { get; set; }
        public string Spartan_Security_Log_IP_Address_Target { get; set; }
        public string Spartan_Security_Log_Computer_Name { get; set; }
        public short? Spartan_Security_Log_Language_Id { get; set; }
        public string Spartan_Security_Log_Language_Id_Language { get; set; }
        public string Spartan_Security_Log_URL { get; set; }
        public short? Spartan_Security_Log_Event_Type { get; set; }
        public string Spartan_Security_Log_Event_Type_Description { get; set; }
        public short? Spartan_Security_Log_Result_Id { get; set; }
        public string Spartan_Security_Log_Result_Id_Description { get; set; }

    }
}
