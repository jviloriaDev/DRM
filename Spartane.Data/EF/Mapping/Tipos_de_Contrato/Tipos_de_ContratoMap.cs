using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Tipos_de_Contrato
{
    public partial class Tipos_de_ContratoMap : EntityTypeConfiguration<Spartane.Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato>
    {
        public Tipos_de_ContratoMap()
        {
            this.ToTable("Tipos_de_Contrato");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
