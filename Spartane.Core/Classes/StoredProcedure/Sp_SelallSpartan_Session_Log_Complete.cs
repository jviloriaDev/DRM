using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Session_Log_Complete : BaseEntity
    {
        public int Session_Log_Id { get; set; }
        public int? Security_Log_Id { get; set; }
        public DateTime? Log_Date { get; set; }
        public int? User_Role_Id { get; set; }
        public string User_Role_Id_Description { get; set; }
        public int? User_Id { get; set; }
        public string User_Id_Name { get; set; }
        public string IP_Address_Source { get; set; }
        public string IP_Address_Target { get; set; }
        public string Computer_Name { get; set; }
        public short? Language_Id { get; set; }
        public string Language_Id_Resource_File { get; set; }
        public string URL { get; set; }
        public short? Event_Type { get; set; }
        public string Event_Type_Description { get; set; }
        public short? Result_Id { get; set; }
        public string Result_Id_Description { get; set; }
        public short? Event_Type2 { get; set; }
        public string Event_Type2_Description { get; set; }

    }
}
