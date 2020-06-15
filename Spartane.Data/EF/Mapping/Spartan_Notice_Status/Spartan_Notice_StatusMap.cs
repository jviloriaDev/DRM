using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Notice_Status
{
    public partial class Spartan_Notice_StatusMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Notice_Status.Spartan_Notice_Status>
    {
        public Spartan_Notice_StatusMap()
        {
            this.ToTable("Spartan_Notice_Status");
            this.HasKey(a => a.Notice_Status_Id);
            this.Ignore(a => a.Id);
        }
    }
}
