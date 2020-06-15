using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Layout_Status
{
    public partial class Spartan_Layout_StatusMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Layout_Status.Spartan_Layout_Status>
    {
        public Spartan_Layout_StatusMap()
        {
            this.ToTable("Spartan_Layout_Status");
            this.HasKey(a => a.Layout_Status_Id);
            this.Ignore(a => a.Id);
        }
    }
}
