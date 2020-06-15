using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_de_Ingredientes
{
    public partial class Detalle_de_IngredientesMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_de_Ingredientes.Detalle_de_Ingredientes>
    {
        public Detalle_de_IngredientesMap()
        {
            this.ToTable("Detalle_de_Ingredientes");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
