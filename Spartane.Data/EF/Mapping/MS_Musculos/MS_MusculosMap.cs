using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.MS_Musculos
{
    public partial class MS_MusculosMap : EntityTypeConfiguration<Spartane.Core.Classes.MS_Musculos.MS_Musculos>
    {
        public MS_MusculosMap()
        {
            this.ToTable("MS_Musculos");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
