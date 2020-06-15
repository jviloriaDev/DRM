using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Identificacion_Oficial_Medicos
{
    public partial class Detalle_Identificacion_Oficial_MedicosMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos>
    {
        public Detalle_Identificacion_Oficial_MedicosMap()
        {
            this.ToTable("Detalle_Identificacion_Oficial_Medicos");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
