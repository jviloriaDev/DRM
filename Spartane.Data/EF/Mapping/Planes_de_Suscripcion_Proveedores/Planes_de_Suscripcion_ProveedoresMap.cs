using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Planes_de_Suscripcion_Proveedores
{
    public partial class Planes_de_Suscripcion_ProveedoresMap : EntityTypeConfiguration<Spartane.Core.Classes.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores>
    {
        public Planes_de_Suscripcion_ProveedoresMap()
        {
            this.ToTable("Planes_de_Suscripcion_Proveedores");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
