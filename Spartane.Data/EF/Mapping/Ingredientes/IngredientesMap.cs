using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Ingredientes
{
    public partial class IngredientesMap : EntityTypeConfiguration<Spartane.Core.Classes.Ingredientes.Ingredientes>
    {
        public IngredientesMap()
        {
            this.ToTable("Ingredientes");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
