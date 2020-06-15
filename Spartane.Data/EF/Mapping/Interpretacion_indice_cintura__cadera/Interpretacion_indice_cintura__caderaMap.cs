using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Interpretacion_indice_cintura__cadera
{
    public partial class Interpretacion_indice_cintura__caderaMap : EntityTypeConfiguration<Spartane.Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera>
    {
        public Interpretacion_indice_cintura__caderaMap()
        {
            this.ToTable("Interpretacion_indice_cintura__cadera");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
