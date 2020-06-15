using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Object_Method_Status
{
    public partial class Spartan_Object_Method_StatusMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Object_Method_Status.Spartan_Object_Method_Status>
    {
        public Spartan_Object_Method_StatusMap()
        {
            this.ToTable("Spartan_Object_Method_Status");
            this.HasKey(a => a.Object_Method_Status_Id);
            this.Ignore(a => a.Id);
        }
    }
}
