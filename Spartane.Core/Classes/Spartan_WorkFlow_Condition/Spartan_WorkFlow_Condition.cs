using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_WorkFlow_Condition
{
    /// <summary>
    /// Spartan_WorkFlow_Condition table
    /// </summary>
    public class Spartan_WorkFlow_Condition: BaseEntity
    {
        public short ConditionId { get; set; }
        public string Description { get; set; }


    }
}

