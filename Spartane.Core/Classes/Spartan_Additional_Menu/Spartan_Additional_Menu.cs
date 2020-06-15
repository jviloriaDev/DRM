using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Spartan_Additional_Menu
{
    public class Spartan_Additional_Menu : BaseEntity
    {
        public int? idMenu { get; set; }
        public string MenuName { get; set; }
        public int? ParentMenu { get; set; }
        public string OptionMenu { get; set; }
        public string OptionPath { get; set; }

        [ForeignKey("ParentMenu")]
        public virtual Spartan_Additional_Menu Menu_ParentMenu { get; set; }
    }
}
