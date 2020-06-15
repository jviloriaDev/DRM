using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Registro_de_Asistencia_Telefonica
{
    public partial class Registro_de_Asistencia_TelefonicaMap : EntityTypeConfiguration<Spartane.Core.Classes.Registro_de_Asistencia_Telefonica.Registro_de_Asistencia_Telefonica>
    {
        public Registro_de_Asistencia_TelefonicaMap()
        {
            this.ToTable("Registro_de_Asistencia_Telefonica");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
