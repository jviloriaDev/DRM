using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Cantidad_fraccion_platillos
{
    public partial class Cantidad_fraccion_platillosMap : EntityTypeConfiguration<Spartane.Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos>
    {
        public Cantidad_fraccion_platillosMap()
        {
            this.ToTable("Cantidad_fraccion_platillos");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
