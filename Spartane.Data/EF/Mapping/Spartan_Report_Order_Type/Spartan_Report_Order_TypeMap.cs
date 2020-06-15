using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Report_Order_Type
{
    public partial class Spartan_Report_Order_TypeMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Report_Order_Type.Spartan_Report_Order_Type>
    {
        public Spartan_Report_Order_TypeMap()
        {
            this.ToTable("Spartan_Report_Order_Type");
            this.HasKey(a => a.OrderTypeId);
            this.Ignore(a => a.Id);
        }
    }
}
