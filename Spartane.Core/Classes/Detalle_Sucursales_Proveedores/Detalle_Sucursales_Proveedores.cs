﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Proveedores;
using Spartane.Core.Classes.Tipo_de_Sucursal;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_Sucursales_Proveedores
{
    /// <summary>
    /// Detalle_Sucursales_Proveedores table
    /// </summary>
    public class Detalle_Sucursales_Proveedores: BaseEntity
    {
        public int Folio { get; set; }
        public int? FolioProveedores { get; set; }
        public int? Tipo_de_Sucursal { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Calle { get; set; }
        public int? Numero_exterior { get; set; }
        public int? Numero_interior { get; set; }
        public string Colonia { get; set; }
        public int? C_P_ { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

        [ForeignKey("FolioProveedores")]
        public virtual Spartane.Core.Classes.Proveedores.Proveedores FolioProveedores_Proveedores { get; set; }
        [ForeignKey("Tipo_de_Sucursal")]
        public virtual Spartane.Core.Classes.Tipo_de_Sucursal.Tipo_de_Sucursal Tipo_de_Sucursal_Tipo_de_Sucursal { get; set; }

    }
}

