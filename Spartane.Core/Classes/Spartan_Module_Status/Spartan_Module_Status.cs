using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Module_Status
{
    /// <summary>
    /// Spartan_Module_Status table
    /// </summary>
    public class Spartan_Module_Status: BaseEntity
    {
        public short Module_Status_Id { get; set; }
        public string Description { get; set; }


    }
}

