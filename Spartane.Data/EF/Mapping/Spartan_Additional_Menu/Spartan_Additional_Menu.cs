using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Data.EF.Mapping.Spartan_Additional_Menu
{
    public class Spartan_Additional_Menu : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Additional_Menu.Spartan_Additional_Menu>
    {
        public Spartan_Additional_Menu()
        {
            this.HasKey(K => K.idMenu);
            this.Ignore(P => P.Id);
        }
    }
}
