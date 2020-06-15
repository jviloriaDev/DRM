using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Token_Type
{
    public partial class Spartan_Token_TypeMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Token_Type.Spartan_Token_Type>
    {
        public Spartan_Token_TypeMap()
        {
            this.ToTable("Spartan_Token_Type");
            this.HasKey(a => a.Token_Type_Id);
            this.Ignore(a => a.Id);
        }
    }
}
