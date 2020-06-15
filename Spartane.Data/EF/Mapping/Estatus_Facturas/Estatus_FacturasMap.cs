using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Estatus_Facturas
{
    public partial class Estatus_FacturasMap : EntityTypeConfiguration<Spartane.Core.Classes.Estatus_Facturas.Estatus_Facturas>
    {
        public Estatus_FacturasMap()
        {
            this.ToTable("Estatus_Facturas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
