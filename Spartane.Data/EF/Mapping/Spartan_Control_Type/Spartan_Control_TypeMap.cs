using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Control_Type
{
    public partial class Spartan_Control_TypeMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Control_Type.Spartan_Control_Type>
    {
        public Spartan_Control_TypeMap()
        {
            this.ToTable("Spartan_Control_Type");
            this.HasKey(a => a.Control_Type_Id);
            this.Ignore(a => a.Id);
        }
    }
}
