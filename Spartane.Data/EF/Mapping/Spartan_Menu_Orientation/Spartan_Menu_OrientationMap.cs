using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Menu_Orientation
{
    public partial class Spartan_Menu_OrientationMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Menu_Orientation.Spartan_Menu_Orientation>
    {
        public Spartan_Menu_OrientationMap()
        {
            this.ToTable("Spartan_Menu_Orientation");
            this.HasKey(a => a.System_Menu_Orientation_Id);
            this.Ignore(a => a.Id);
        }
    }
}
