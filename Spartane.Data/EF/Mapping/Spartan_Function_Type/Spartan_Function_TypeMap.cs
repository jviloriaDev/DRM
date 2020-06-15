using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Function_Type
{
    public partial class Spartan_Function_TypeMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Function_Type.Spartan_Function_Type>
    {
        public Spartan_Function_TypeMap()
        {
            this.ToTable("Spartan_Function_Type");
            this.HasKey(a => a.Function_Type_Id);
            this.Ignore(a => a.Id);
        }
    }
}
