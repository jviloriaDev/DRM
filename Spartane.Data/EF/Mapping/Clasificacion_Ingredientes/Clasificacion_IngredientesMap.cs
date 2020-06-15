using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Clasificacion_Ingredientes
{
    public partial class Clasificacion_IngredientesMap : EntityTypeConfiguration<Spartane.Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes>
    {
        public Clasificacion_IngredientesMap()
        {
            this.ToTable("Clasificacion_Ingredientes");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
