using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Notice_Type
{
    public partial class Spartan_Notice_TypeMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Notice_Type.Spartan_Notice_Type>
    {
        public Spartan_Notice_TypeMap()
        {
            this.ToTable("Spartan_Notice_Type");
            this.HasKey(a => a.Notice_Type_Id);
            this.Ignore(a => a.Id);
        }
    }
}
