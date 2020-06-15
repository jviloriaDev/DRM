using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_User_Alert_Type
{
    public partial class Spartan_User_Alert_TypeMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_User_Alert_Type.Spartan_User_Alert_Type>
    {
        public Spartan_User_Alert_TypeMap()
        {
            this.ToTable("Spartan_User_Alert_Type");
            this.HasKey(a => a.User_Alert_Type_Id);
            this.Ignore(a => a.Id);
        }
    }
}
