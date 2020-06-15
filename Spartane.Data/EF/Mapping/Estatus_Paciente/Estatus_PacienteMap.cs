using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Estatus_Paciente
{
    public partial class Estatus_PacienteMap : EntityTypeConfiguration<Spartane.Core.Classes.Estatus_Paciente.Estatus_Paciente>
    {
        public Estatus_PacienteMap()
        {
            this.ToTable("Estatus_Paciente");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
