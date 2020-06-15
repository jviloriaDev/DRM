using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Suscripcion_Red_de_Especialistas_Proveedores
{
    public partial class Detalle_Suscripcion_Red_de_Especialistas_ProveedoresMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores>
    {
        public Detalle_Suscripcion_Red_de_Especialistas_ProveedoresMap()
        {
            this.ToTable("Detalle_Suscripcion_Red_de_Especialistas_Proveedores");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
