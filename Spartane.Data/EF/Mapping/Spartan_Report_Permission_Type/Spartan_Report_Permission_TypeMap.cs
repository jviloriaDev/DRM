using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Report_Permission_Type
{
    public partial class Spartan_Report_Permission_TypeMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Report_Permission_Type.Spartan_Report_Permission_Type>
    {
        public Spartan_Report_Permission_TypeMap()
        {
            this.ToTable("Spartan_Report_Permission_Type");
            this.HasKey(a => a.PermissionTypeId);
            this.Ignore(a => a.Id);
        }
    }
}
