using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Order_Type
{
    public partial class Spartan_Order_TypeMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Order_Type.Spartan_Order_Type>
    {
        public Spartan_Order_TypeMap()
        {
            this.ToTable("Spartan_Order_Type");
            this.HasKey(a => a.Order_Type_Id);
            this.Ignore(a => a.Id);
        }
    }
}
