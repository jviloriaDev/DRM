using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Tipos_de_Actividades
{
    public partial class Tipos_de_ActividadesMap : EntityTypeConfiguration<Spartane.Core.Classes.Tipos_de_Actividades.Tipos_de_Actividades>
    {
        public Tipos_de_ActividadesMap()
        {
            this.ToTable("Tipos_de_Actividades");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
