using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Object_Status
{
    public partial class Spartan_Object_StatusMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Object_Status.Spartan_Object_Status>
    {
        public Spartan_Object_StatusMap()
        {
            this.ToTable("Spartan_Object_Status");
            this.HasKey(a => a.Object_Status_Id);
            this.Ignore(a => a.Id);
        }
    }
}
