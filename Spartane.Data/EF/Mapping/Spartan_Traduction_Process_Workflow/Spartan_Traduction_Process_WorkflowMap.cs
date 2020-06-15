using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Traduction_Process_Workflow
{
    public partial class Spartan_Traduction_Process_WorkflowMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow>
    {
        public Spartan_Traduction_Process_WorkflowMap()
        {
            this.ToTable("Spartan_Traduction_Process_Workflow");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
