using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_System;
using Spartane.Core.Classes.Spartan_Menu_Style;
using Spartane.Core.Classes.Spartan_Menu_Orientation;
using Spartane.Core.Classes.Spartan_Layout_Status;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_System_Layout
{
    /// <summary>
    /// Spartan_System_Layout table
    /// </summary>
    public class Spartan_System_Layout: BaseEntity
    {
        public int System_Layout_Id { get; set; }
        public short? System_Id { get; set; }
        public short? Menu_Style_Id { get; set; }
        public string Description { get; set; }
        public string Layout_URL { get; set; }
        public string Class_URL { get; set; }
        public short? Orientation { get; set; }
        public short? Layout_Status { get; set; }

        [ForeignKey("System_Id")]
        public virtual Spartane.Core.Classes.Spartan_System.Spartan_System System_Id_Spartan_System { get; set; }
        [ForeignKey("Menu_Style_Id")]
        public virtual Spartane.Core.Classes.Spartan_Menu_Style.Spartan_Menu_Style Menu_Style_Id_Spartan_Menu_Style { get; set; }
        [ForeignKey("Orientation")]
        public virtual Spartane.Core.Classes.Spartan_Menu_Orientation.Spartan_Menu_Orientation Orientation_Spartan_Menu_Orientation { get; set; }
        [ForeignKey("Layout_Status")]
        public virtual Spartane.Core.Classes.Spartan_Layout_Status.Spartan_Layout_Status Layout_Status_Spartan_Layout_Status { get; set; }

    }
}

