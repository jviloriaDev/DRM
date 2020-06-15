using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Function_Status
{
    public partial class Spartan_Function_StatusMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Function_Status.Spartan_Function_Status>
    {
        public Spartan_Function_StatusMap()
        {
            this.ToTable("Spartan_Function_Status");
            this.HasKey(a => a.Function_Status_Id);
            this.Ignore(a => a.Id);
        }
    }
}
