using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Frecuencia_de_pago_Empresas
{
    public partial class Frecuencia_de_pago_EmpresasMap : EntityTypeConfiguration<Spartane.Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas>
    {
        public Frecuencia_de_pago_EmpresasMap()
        {
            this.ToTable("Frecuencia_de_pago_Empresas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
