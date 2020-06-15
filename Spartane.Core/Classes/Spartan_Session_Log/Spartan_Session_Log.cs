using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_User_Role;
using Spartane.Core.Classes.Spartan_User;
using Spartane.Core.Classes.Spartan_System_Language;
using Spartane.Core.Classes.Spartan_Security_Event_Type;
using Spartane.Core.Classes.Spartan_Security_Event_Result;
using Spartane.Core.Classes.Spartan_Session_Event_Type;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Session_Log
{
    /// <summary>
    /// Spartan_Session_Log table
    /// </summary>
    public class Spartan_Session_Log: BaseEntity
    {
        public int Session_Log_Id { get; set; }
        public int? Security_Log_Id { get; set; }
        public DateTime? Log_Date { get; set; }
        public int? User_Role_Id { get; set; }
        public int? User_Id { get; set; }
        public string IP_Address_Source { get; set; }
        public string IP_Address_Target { get; set; }
        public string Computer_Name { get; set; }
        public short? Language_Id { get; set; }
        public string URL { get; set; }
        public short? Event_Type { get; set; }
        public short? Result_Id { get; set; }
        public short? Event_Type2 { get; set; }

        [ForeignKey("User_Role_Id")]
        public virtual Spartane.Core.Classes.Spartan_User_Role.Spartan_User_Role User_Role_Id_Spartan_User_Role { get; set; }
        [ForeignKey("User_Id")]
        public virtual Spartane.Core.Classes.Spartan_User.Spartan_User User_Id_Spartan_User { get; set; }
        [ForeignKey("Language_Id")]
        public virtual Spartane.Core.Classes.Spartan_System_Language.Spartan_System_Language Language_Id_Spartan_System_Language { get; set; }
        [ForeignKey("Event_Type")]
        public virtual Spartane.Core.Classes.Spartan_Security_Event_Type.Spartan_Security_Event_Type Event_Type_Spartan_Security_Event_Type { get; set; }
        [ForeignKey("Result_Id")]
        public virtual Spartane.Core.Classes.Spartan_Security_Event_Result.Spartan_Security_Event_Result Result_Id_Spartan_Security_Event_Result { get; set; }
        [ForeignKey("Event_Type2")]
        public virtual Spartane.Core.Classes.Spartan_Session_Event_Type.Spartan_Session_Event_Type Event_Type2_Spartan_Session_Event_Type { get; set; }

    }
}

