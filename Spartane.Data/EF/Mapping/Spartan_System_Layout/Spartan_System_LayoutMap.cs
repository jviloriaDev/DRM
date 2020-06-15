using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_System_Layout
{
    public partial class Spartan_System_LayoutMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_System_Layout.Spartan_System_Layout>
    {
        public Spartan_System_LayoutMap()
        {
            this.ToTable("Spartan_System_Layout");
            this.HasKey(a => a.System_Layout_Id);
            this.Ignore(a => a.Id);
        }
    }
}
