using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Tiempos_de_Comida
{
    public partial class Tiempos_de_ComidaMap : EntityTypeConfiguration<Spartane.Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida>
    {
        public Tiempos_de_ComidaMap()
        {
            this.ToTable("Tiempos_de_Comida");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
