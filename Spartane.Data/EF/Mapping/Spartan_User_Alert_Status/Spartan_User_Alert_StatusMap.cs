using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_User_Alert_Status
{
    public partial class Spartan_User_Alert_StatusMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_User_Alert_Status.Spartan_User_Alert_Status>
    {
        public Spartan_User_Alert_StatusMap()
        {
            this.ToTable("Spartan_User_Alert_Status");
            this.HasKey(a => a.User_Alert_Status_Id);
            this.Ignore(a => a.Id);
        }
    }
}
