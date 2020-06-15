using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_User_Alert_Status
{
    /// <summary>
    /// Spartan_User_Alert_Status table
    /// </summary>
    public class Spartan_User_Alert_Status: BaseEntity
    {
        public short User_Alert_Status_Id { get; set; }
        public string Description { get; set; }


    }
}

