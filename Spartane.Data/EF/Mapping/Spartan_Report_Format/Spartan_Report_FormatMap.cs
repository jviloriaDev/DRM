using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Report_Format
{
    public partial class Spartan_Report_FormatMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Report_Format.Spartan_Report_Format>
    {
        public Spartan_Report_FormatMap()
        {
            this.ToTable("Spartan_Report_Format");
            this.HasKey(a => a.FormatId);
            this.Ignore(a => a.Id);
        }
    }
}
