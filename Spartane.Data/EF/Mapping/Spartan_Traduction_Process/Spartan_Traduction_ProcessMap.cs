using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Traduction_Process
{
    public partial class Spartan_Traduction_ProcessMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Traduction_Process.Spartan_Traduction_Process>
    {
        public Spartan_Traduction_ProcessMap()
        {
            this.ToTable("Spartan_Traduction_Process");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.IdTraduction);
        }
    }
}
