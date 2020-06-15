using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Especialistas_Pacientes
{
    public partial class Detalle_Especialistas_PacientesMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes>
    {
        public Detalle_Especialistas_PacientesMap()
        {
            this.ToTable("Detalle_Especialistas_Pacientes");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
