using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Respuesta_Logica
{
    public partial class Respuesta_LogicaMap : EntityTypeConfiguration<Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica>
    {
        public Respuesta_LogicaMap()
        {
            this.ToTable("Respuesta_Logica");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
