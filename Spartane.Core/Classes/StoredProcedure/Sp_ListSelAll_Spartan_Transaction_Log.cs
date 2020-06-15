using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Transaction_Log : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Transaction_Log_Transaction_Log_Id { get; set; }
        public int? Spartan_Transaction_Log_Session_Log_Id { get; set; }
        public int Spartan_Transaction_Log_Session_Log_Id_Security_Log_Id { get; set; }
        public DateTime? Spartan_Transaction_Log_Log_Date { get; set; }
        public short? Spartan_Transaction_Log_Module_Id { get; set; }
        public string Spartan_Transaction_Log_Module_Id_Name { get; set; }
        public int? Spartan_Transaction_Log_Object_Id { get; set; }
        public string Spartan_Transaction_Log_Object_Id_Name { get; set; }
        public short? Spartan_Transaction_Log_Function_Id { get; set; }
        public string Spartan_Transaction_Log_Function_Id_Description { get; set; }
        public int? Spartan_Transaction_Log_Log_Type_Id { get; set; }
        public string Spartan_Transaction_Log_Log_Type_Id_Description { get; set; }
        public short? Spartan_Transaction_Log_Event_Type_Id { get; set; }
        public string Spartan_Transaction_Log_Event_Type_Id_Description { get; set; }

    }
}
