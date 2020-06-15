using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_System
{
    public partial class Spartan_SystemMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_System.Spartan_System>
    {
        public Spartan_SystemMap()
        {
            this.ToTable("Spartan_System");
            this.HasKey(a => a.System_Id);
            this.Ignore(a => a.Id);
        }
    }
}
