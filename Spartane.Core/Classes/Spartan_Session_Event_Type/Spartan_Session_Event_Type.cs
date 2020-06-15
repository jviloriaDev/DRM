using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Session_Event_Type
{
    /// <summary>
    /// Spartan_Session_Event_Type table
    /// </summary>
    public class Spartan_Session_Event_Type: BaseEntity
    {
        public short Session_Event_Type_Id { get; set; }
        public string Description { get; set; }


    }
}

