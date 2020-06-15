using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Format
{
    public partial class Spartan_FormatMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Format.Spartan_Format>
    {
        public Spartan_FormatMap()
        {
            this.ToTable("Spartan_Format");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.FormatId);
        }
    }
}
