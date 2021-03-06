﻿using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Contratos_Empresa
{
    public partial class Detalle_Contratos_EmpresaMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Contratos_Empresa.Detalle_Contratos_Empresa>
    {
        public Detalle_Contratos_EmpresaMap()
        {
            this.ToTable("Detalle_Contratos_Empresa");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
