using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_pantalla_Francisco
{
    public partial class Detalle_pantalla_FranciscoMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_pantalla_Francisco.Detalle_pantalla_Francisco>
    {
        public Detalle_pantalla_FranciscoMap()
        {
            this.ToTable("Detalle_pantalla_Francisco");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
