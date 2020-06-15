using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_Event_Type;
using Spartane.Core.Classes.Spartan_Function;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Function_Event
{
    /// <summary>
    /// Spartan_Function_Event table
    /// </summary>
    public class Spartan_Function_Event: BaseEntity
    {
        public short Function_Event_Id { get; set; }
        public short? Event_Type_Id { get; set; }
        public short Spartan_Function { get; set; }

        [ForeignKey("Event_Type_Id")]
        public virtual Spartane.Core.Classes.Spartan_Event_Type.Spartan_Event_Type Event_Type_Id_Spartan_Event_Type { get; set; }
        [ForeignKey("Spartan_Function")]
        public virtual Spartane.Core.Classes.Spartan_Function.Spartan_Function Spartan_Function_Spartan_Function { get; set; }

    }
}

