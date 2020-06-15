using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Pacientes
{
    public partial class PacientesMap : EntityTypeConfiguration<Spartane.Core.Classes.Pacientes.Pacientes>
    {
        public PacientesMap()
        {
            this.ToTable("Pacientes");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
