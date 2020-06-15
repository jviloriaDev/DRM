using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_WorkFlow
{
    public partial class Spartan_WorkFlowMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_WorkFlow.Spartan_WorkFlow>
    {
        public Spartan_WorkFlowMap()
        {
            this.ToTable("Spartan_WorkFlow");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.WorkFlowId);
        }
    }
}
