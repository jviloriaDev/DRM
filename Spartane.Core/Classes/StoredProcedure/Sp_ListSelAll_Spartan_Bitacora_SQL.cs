using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Bitacora_SQL : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Bitacora_SQL_Folio { get; set; }
        public int? Spartan_Bitacora_SQL_Id_User { get; set; }
        public string Spartan_Bitacora_SQL_Type_SQL { get; set; }
        public DateTime? Spartan_Bitacora_SQL_Register_Date { get; set; }
        public string Spartan_Bitacora_SQL_Computer_Name { get; set; }
        public string Spartan_Bitacora_SQL_Server_Name { get; set; }
        public string Spartan_Bitacora_SQL_Database_Name { get; set; }
        public string Spartan_Bitacora_SQL_System_Name { get; set; }
        public string Spartan_Bitacora_SQL_System_Version { get; set; }
        public string Spartan_Bitacora_SQL_Windows_Version { get; set; }
        public string Spartan_Bitacora_SQL_Command_SQL { get; set; }
        public string Spartan_Bitacora_SQL_Folio_SQL { get; set; }
        public int? Spartan_Bitacora_SQL_Object_Id { get; set; }
        public string Spartan_Bitacora_SQL_IP { get; set; }
        public string Spartan_Bitacora_SQL_Json { get; set; }
        public bool? Spartan_Bitacora_SQL_Result { get; set; }
        public string Spartan_Bitacora_SQL_Error { get; set; }

    }
}
