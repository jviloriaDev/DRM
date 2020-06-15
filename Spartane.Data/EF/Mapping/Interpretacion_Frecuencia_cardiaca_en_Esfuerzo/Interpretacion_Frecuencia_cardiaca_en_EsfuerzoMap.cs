using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo
{
    public partial class Interpretacion_Frecuencia_cardiaca_en_EsfuerzoMap : EntityTypeConfiguration<Spartane.Core.Classes.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo>
    {
        public Interpretacion_Frecuencia_cardiaca_en_EsfuerzoMap()
        {
            this.ToTable("Interpretacion_Frecuencia_cardiaca_en_Esfuerzo");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
