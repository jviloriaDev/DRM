using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Layout_Status
{
    /// <summary>
    /// Spartan_Layout_Status table
    /// </summary>
    public class Spartan_Layout_Status: BaseEntity
    {
        public short Layout_Status_Id { get; set; }
        public string Description { get; set; }


    }
}

