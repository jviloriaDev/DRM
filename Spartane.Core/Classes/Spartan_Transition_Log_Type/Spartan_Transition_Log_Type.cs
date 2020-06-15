using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Transition_Log_Type
{
    /// <summary>
    /// Spartan_Transition_Log_Type table
    /// </summary>
    public class Spartan_Transition_Log_Type: BaseEntity
    {
        public short Transaction_Log_Type_Id { get; set; }
        public string Description { get; set; }


    }
}

