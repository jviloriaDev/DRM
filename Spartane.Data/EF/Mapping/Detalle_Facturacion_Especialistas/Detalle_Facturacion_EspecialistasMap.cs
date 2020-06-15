using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Facturacion_Especialistas
{
    public partial class Detalle_Facturacion_EspecialistasMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Facturacion_Especialistas.Detalle_Facturacion_Especialistas>
    {
        public Detalle_Facturacion_EspecialistasMap()
        {
            this.ToTable("Detalle_Facturacion_Especialistas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
