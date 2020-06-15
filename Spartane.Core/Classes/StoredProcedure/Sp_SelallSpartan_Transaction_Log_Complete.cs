using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Transaction_Log_Complete : BaseEntity
    {
        public int Transaction_Log_Id { get; set; }
        public int? Session_Log_Id { get; set; }
        public int Session_Log_Id_Security_Log_Id { get; set; }
        public DateTime? Log_Date { get; set; }
        public short? Module_Id { get; set; }
        public string Module_Id_Name { get; set; }
        public int? Object_Id { get; set; }
        public string Object_Id_Name { get; set; }
        public short? Function_Id { get; set; }
        public string Function_Id_Description { get; set; }
        public int? Log_Type_Id { get; set; }
        public string Log_Type_Id_Description { get; set; }
        public short? Event_Type_Id { get; set; }
        public string Event_Type_Id_Description { get; set; }

    }
}
