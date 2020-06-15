using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_BR_Action_Result
{
    /// <summary>
    /// Spartan_BR_Action_Result table
    /// </summary>
    public class Spartan_BR_Action_Result: BaseEntity
    {
        public short ActionResultId { get; set; }
        public string Description { get; set; }


    }
}

