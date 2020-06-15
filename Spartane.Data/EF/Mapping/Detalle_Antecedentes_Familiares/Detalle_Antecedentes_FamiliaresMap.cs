using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Antecedentes_Familiares
{
    public partial class Detalle_Antecedentes_FamiliaresMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares>
    {
        public Detalle_Antecedentes_FamiliaresMap()
        {
            this.ToTable("Detalle_Antecedentes_Familiares");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
