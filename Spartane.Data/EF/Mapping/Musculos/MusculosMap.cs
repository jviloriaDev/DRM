using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Musculos
{
    public partial class MusculosMap : EntityTypeConfiguration<Spartane.Core.Classes.Musculos.Musculos>
    {
        public MusculosMap()
        {
            this.ToTable("Musculos");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
