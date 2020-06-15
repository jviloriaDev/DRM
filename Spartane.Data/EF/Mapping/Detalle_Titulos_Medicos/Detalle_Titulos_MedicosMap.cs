using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Titulos_Medicos
{
    public partial class Detalle_Titulos_MedicosMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos>
    {
        public Detalle_Titulos_MedicosMap()
        {
            this.ToTable("Detalle_Titulos_Medicos");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
