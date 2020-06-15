using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Method_Type_Status
{
    public partial class Spartan_Method_Type_StatusMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Method_Type_Status.Spartan_Method_Type_Status>
    {
        public Spartan_Method_Type_StatusMap()
        {
            this.ToTable("Spartan_Method_Type_Status");
            this.HasKey(a => a.Method_Type_Status_Id);
            this.Ignore(a => a.Id);
        }
    }
}
