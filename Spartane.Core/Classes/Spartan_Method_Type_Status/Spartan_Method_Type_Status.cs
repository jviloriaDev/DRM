using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Method_Type_Status
{
    /// <summary>
    /// Spartan_Method_Type_Status table
    /// </summary>
    public class Spartan_Method_Type_Status: BaseEntity
    {
        public short Method_Type_Status_Id { get; set; }
        public string Description { get; set; }


    }
}

