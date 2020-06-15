using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_WorkFlow_Phases
{
    public partial class Spartan_WorkFlow_PhasesMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases>
    {
        public Spartan_WorkFlow_PhasesMap()
        {
            this.ToTable("Spartan_WorkFlow_Phases");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.PhasesId);
        }
    }
}
