using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Method_Type
{
    public partial class Spartan_Method_TypeMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Method_Type.Spartan_Method_Type>
    {
        public Spartan_Method_TypeMap()
        {
            this.ToTable("Spartan_Method_Type");
            this.HasKey(a => a.Method_Type_Id);
            this.Ignore(a => a.Id);
        }
    }
}
