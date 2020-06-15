using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Pagos_Paciente
{
    public partial class Detalle_Pagos_PacienteMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Pagos_Paciente.Detalle_Pagos_Paciente>
    {
        public Detalle_Pagos_PacienteMap()
        {
            this.ToTable("Detalle_Pagos_Paciente");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
