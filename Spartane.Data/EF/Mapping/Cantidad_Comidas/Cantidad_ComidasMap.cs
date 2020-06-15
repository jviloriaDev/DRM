using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Cantidad_Comidas
{
    public partial class Cantidad_ComidasMap : EntityTypeConfiguration<Spartane.Core.Classes.Cantidad_Comidas.Cantidad_Comidas>
    {
        public Cantidad_ComidasMap()
        {
            this.ToTable("Cantidad_Comidas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
