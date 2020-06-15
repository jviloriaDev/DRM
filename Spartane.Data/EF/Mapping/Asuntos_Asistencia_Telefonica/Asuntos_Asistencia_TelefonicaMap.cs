using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Asuntos_Asistencia_Telefonica
{
    public partial class Asuntos_Asistencia_TelefonicaMap : EntityTypeConfiguration<Spartane.Core.Classes.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica>
    {
        public Asuntos_Asistencia_TelefonicaMap()
        {
            this.ToTable("Asuntos_Asistencia_Telefonica");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
