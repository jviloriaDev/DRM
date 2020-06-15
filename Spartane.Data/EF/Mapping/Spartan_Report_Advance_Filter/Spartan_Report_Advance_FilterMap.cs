using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Report_Advance_Filter
{
    public partial class Spartan_Report_Advance_FilterMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter>
    {
        public Spartan_Report_Advance_FilterMap()
        {
            this.ToTable("Spartan_Report_Advance_Filter");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
