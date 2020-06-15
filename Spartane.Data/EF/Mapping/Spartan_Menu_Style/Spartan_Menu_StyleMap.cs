using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Menu_Style
{
    public partial class Spartan_Menu_StyleMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Menu_Style.Spartan_Menu_Style>
    {
        public Spartan_Menu_StyleMap()
        {
            this.ToTable("Spartan_Menu_Style");
            this.HasKey(a => a.Menu_Style_Id);
            this.Ignore(a => a.Id);
        }
    }
}
