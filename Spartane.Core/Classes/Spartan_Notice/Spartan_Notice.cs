using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_Notice_Type;
using Spartane.Core.Classes.Spartan_Notice_Status;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Notice
{
    /// <summary>
    /// Spartan_Notice table
    /// </summary>
    public class Spartan_Notice: BaseEntity
    {
        public int Notice_Id { get; set; }
        public string Description { get; set; }
        public int? Notice_Type { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public short? Status { get; set; }

        [ForeignKey("Notice_Type")]
        public virtual Spartane.Core.Classes.Spartan_Notice_Type.Spartan_Notice_Type Notice_Type_Spartan_Notice_Type { get; set; }
        [ForeignKey("Status")]
        public virtual Spartane.Core.Classes.Spartan_Notice_Status.Spartan_Notice_Status Status_Spartan_Notice_Status { get; set; }

    }
}

