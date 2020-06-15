using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_WorkFlow_Type_Flow_Control
{
    public partial class Spartan_WorkFlow_Type_Flow_ControlMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control>
    {
        public Spartan_WorkFlow_Type_Flow_ControlMap()
        {
            this.ToTable("Spartan_WorkFlow_Type_Flow_Control");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Type_Flow_ControlId);
        }
    }
}
