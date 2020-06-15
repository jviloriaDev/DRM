using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Dashboard_Status
{
    /// <summary>
    /// Dashboard_Status table
    /// </summary>
    public class Dashboard_Status: BaseEntity
    {
        public short Status_Id { get; set; }
        public string Description { get; set; }


    }
}

