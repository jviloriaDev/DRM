using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Caracteristicas_Ingrediente
{
    public partial class Detalle_Caracteristicas_IngredienteMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente>
    {
        public Detalle_Caracteristicas_IngredienteMap()
        {
            this.ToTable("Detalle_Caracteristicas_Ingrediente");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
