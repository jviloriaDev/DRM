using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Aseguradoras
{
    public partial class AseguradorasMap : EntityTypeConfiguration<Spartane.Core.Classes.Aseguradoras.Aseguradoras>
    {
        public AseguradorasMap()
        {
            this.ToTable("Aseguradoras");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
