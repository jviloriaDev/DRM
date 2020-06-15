using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Security_Event_Result
{
    /// <summary>
    /// Spartan_Security_Event_Result table
    /// </summary>
    public class Spartan_Security_Event_Result: BaseEntity
    {
        public short Security_Event_Result_Id { get; set; }
        public string Description { get; set; }


    }
}

