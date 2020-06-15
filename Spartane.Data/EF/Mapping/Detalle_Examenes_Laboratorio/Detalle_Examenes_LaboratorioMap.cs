using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Examenes_Laboratorio
{
    public partial class Detalle_Examenes_LaboratorioMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio>
    {
        public Detalle_Examenes_LaboratorioMap()
        {
            this.ToTable("Detalle_Examenes_Laboratorio");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
