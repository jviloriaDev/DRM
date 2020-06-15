using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Tipo_de_Sucursal
{
    public partial class Tipo_de_SucursalMap : EntityTypeConfiguration<Spartane.Core.Classes.Tipo_de_Sucursal.Tipo_de_Sucursal>
    {
        public Tipo_de_SucursalMap()
        {
            this.ToTable("Tipo_de_Sucursal");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
