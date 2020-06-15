using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Antecedentes_No_Patologicos
{
    public partial class Detalle_Antecedentes_No_PatologicosMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos>
    {
        public Detalle_Antecedentes_No_PatologicosMap()
        {
            this.ToTable("Detalle_Antecedentes_No_Patologicos");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
