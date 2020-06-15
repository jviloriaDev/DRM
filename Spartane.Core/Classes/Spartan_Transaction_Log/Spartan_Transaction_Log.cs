using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_Session_Log;
using Spartane.Core.Classes.Spartan_Module;
using Spartane.Core.Classes.Spartan_Object;
using Spartane.Core.Classes.Spartan_Transition_Log_Type;
using Spartane.Core.Classes.Spartan_Transition_Event_Type;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Transaction_Log
{
    /// <summary>
    /// Spartan_Transaction_Log table
    /// </summary>
    public class Spartan_Transaction_Log: BaseEntity
    {
        public int Transaction_Log_Id { get; set; }
        public int? Session_Log_Id { get; set; }
        public DateTime? Log_Date { get; set; }
        public short? Module_Id { get; set; }
        public int? Object_Id { get; set; }
        public short? Function_Id { get; set; }
        public int? Log_Type_Id { get; set; }
        public short? Event_Type_Id { get; set; }

        [ForeignKey("Session_Log_Id")]
        public virtual Spartane.Core.Classes.Spartan_Session_Log.Spartan_Session_Log Session_Log_Id_Spartan_Session_Log { get; set; }
        [ForeignKey("Module_Id")]
        public virtual Spartane.Core.Classes.Spartan_Module.Spartan_Module Module_Id_Spartan_Module { get; set; }
        [ForeignKey("Object_Id")]
        public virtual Spartane.Core.Classes.Spartan_Object.Spartan_Object Object_Id_Spartan_Object { get; set; }
        [ForeignKey("Function_Id")]
        public virtual Spartane.Core.Classes.Spartan_Transition_Log_Type.Spartan_Transition_Log_Type Function_Id_Spartan_Transition_Log_Type { get; set; }
        [ForeignKey("Log_Type_Id")]
        public virtual Spartane.Core.Classes.Spartan_Transition_Event_Type.Spartan_Transition_Event_Type Log_Type_Id_Spartan_Transition_Event_Type { get; set; }
        [ForeignKey("Event_Type_Id")]
        public virtual Spartane.Core.Classes.Spartan_Transition_Log_Type.Spartan_Transition_Log_Type Event_Type_Id_Spartan_Transition_Log_Type { get; set; }

    }
}

