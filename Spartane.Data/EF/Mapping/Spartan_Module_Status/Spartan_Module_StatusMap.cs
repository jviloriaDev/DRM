using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Module_Status
{
    public partial class Spartan_Module_StatusMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Module_Status.Spartan_Module_Status>
    {
        public Spartan_Module_StatusMap()
        {
            this.ToTable("Spartan_Module_Status");
            this.HasKey(a => a.Module_Status_Id);
            this.Ignore(a => a.Id);
        }
    }
}
